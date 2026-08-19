using Application.Dtos;
using Application.Interfaces;
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

            return new LoginResponse
            {
                Token = token,
                ExpiresAtUtc = expiresAtUtc,
                UserId = user.Id,
                UserName = user.UserName ?? "",
                FullName = user.FullName,
                Role = user.Role,
                Company = user.Company,
                MustChangePassword = mustChangePassword
            };
        }
    }
}
