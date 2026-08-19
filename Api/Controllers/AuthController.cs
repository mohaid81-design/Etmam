using Application.Dtos;
using Application.Services;
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

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request, CancellationToken ct)
        {
            var result = await _authService.LoginAsync(request, ct);
            if (result is null)
                return Unauthorized(new { message = "اسم المستخدم أو كلمة المرور غير صحيحة" });

            return Ok(result);
        }
    }
}
