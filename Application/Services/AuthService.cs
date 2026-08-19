using Application.Dtos;
using Application.Interfaces;
using Core;
using Core.Security;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    /// <summary>
    /// Mirrors Etmam/Gui/MainPage/frmLogin.cs's authentication logic (username/active/not-deleted
    /// lookup, PBKDF2 verify, transparent legacy-plaintext rehash) so login behaves identically
    /// whether it runs in-process (legacy screens) or through this API.
    /// </summary>
    public sealed class AuthService
    {
        private readonly IApplicationDbContext _db;
        private readonly IJwtTokenGenerator _jwt;

        public AuthService(IApplicationDbContext db, IJwtTokenGenerator jwt)
        {
            _db = db;
            _jwt = jwt;
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest request, CancellationToken ct = default)
        {
            var user = await _db.UsersList
                .Where(u => u.UserName == request.UserName && u.IsActive && !u.IsDelete)
                .FirstOrDefaultAsync(ct);

            if (user is null || !PasswordHasher.Verify(request.Password, user.Password))
                return null;

            // "0000" is a sentinel meaning "force password change" and is left unhashed on purpose.
            if (!PasswordHasher.IsHashed(user.Password) && user.Password != "0000")
            {
                user.Password = PasswordHasher.Hash(request.Password);
                await _db.SaveChangesAsync(ct);
            }

            var (token, expiresAtUtc) = _jwt.Generate(user);

            var mustChangePassword = user.IsFirstLogin
                || user.Password == "0000"
                || string.IsNullOrWhiteSpace(user.FullName)
                || string.IsNullOrWhiteSpace(user.JobTitle)
                || string.IsNullOrWhiteSpace(user.Company);

            // Replaces frmLogin.LogAction's client-side DC.ActionLogs.Add - moving it here means
            // every successful login gets audited regardless of which client (WinForms, Mobile,
            // Web) authenticated, instead of only whichever caller remembered to log it. MachineName
            // uses the API process's own Environment.MachineName, which is correct today because
            // Api.exe only ever runs as a child process on the same machine as its Etmam.exe caller
            // (see Etmam/Code/Api/ApiProcessManager.cs) - would need to become a request field if
            // the API is ever hosted centrally for multiple remote clients.
            _db.ActionLogs.Add(new ActionLogs
            {
                UserID = user.Id,
                UserName = user.UserName ?? "Unknown",
                ActionType = "دخول",
                ActionLocation = "شاشة الدخول",
                ActionDate = DateTime.Now,
                MachineName = Environment.MachineName
            });
            await _db.SaveChangesAsync(ct);

            return new LoginResponse
            {
                Token = token,
                ExpiresAtUtc = expiresAtUtc,
                UserId = user.Id,
                UserName = user.UserName ?? "",
                FullName = user.FullName,
                JobTitle = user.JobTitle,
                Role = user.Role,
                Company = user.Company,
                MustChangePassword = mustChangePassword
            };
        }

        public async Task CompleteProfileAsync(int userId, CompleteProfileRequest request, CancellationToken ct = default)
        {
            var user = await _db.UsersList.FirstOrDefaultAsync(u => u.Id == userId, ct)
                ?? throw new KeyNotFoundException();

            // Same rules as the client-side check this replaces (Etmam/Gui/MainPage/frmUpdatePassword.cs) -
            // "0000" is the forced-change sentinel itself, so it can never become the new password.
            if (string.IsNullOrEmpty(request.NewPassword) || request.NewPassword.Length < 4 || request.NewPassword == "0000")
                throw new ArgumentException("كلمة المرور يجب أن تكون 4 أحرف على الأقل ولا يمكن أن تكون '0000'.");

            user.FullName = request.FullName;
            user.JobTitle = request.JobTitle;
            user.Company = request.Company;
            user.Password = PasswordHasher.Hash(request.NewPassword);
            user.IsFirstLogin = false;

            await _db.SaveChangesAsync(ct);
        }
    }
}
