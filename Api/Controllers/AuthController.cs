using System.IdentityModel.Tokens.Jwt;
using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public sealed class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        private int CurrentUserId =>
            int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)!.Value);

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request, CancellationToken ct)
        {
            var result = await _authService.LoginAsync(request, ct);
            if (result is null)
                return Unauthorized(new { message = "اسم المستخدم أو كلمة المرور غير صحيحة" });

            return Ok(result);
        }

        // Called from frmUpdatePassword.cs's mandatory first-login flow - authenticated with the
        // token Login just issued (MustChangePassword doesn't block the token from being usable,
        // only gates the WinForms client's own navigation past frmLogin).
        [Authorize]
        [HttpPut("complete-profile")]
        public async Task<IActionResult> CompleteProfile(CompleteProfileRequest request, CancellationToken ct)
        {
            try
            {
                await _authService.CompleteProfileAsync(CurrentUserId, request, ct);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
