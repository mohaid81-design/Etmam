namespace Application.Dtos
{
    public sealed class LoginRequest
    {
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public sealed class LoginResponse
    {
        public string Token { get; set; } = "";
        public DateTime ExpiresAtUtc { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = "";
        public string? FullName { get; set; }
        public string? JobTitle { get; set; }
        public string? Role { get; set; }
        public string? Company { get; set; }

        // Mirrors frmLogin.HandleSuccessfulLogin's mandatory-update condition, so the client
        // knows to show the password/profile-completion flow without re-deriving the rule.
        public bool MustChangePassword { get; set; }
    }

    // frmUpdatePassword's mandatory first-login flow: fills in the profile fields AuthService's
    // MustChangePassword check requires, and sets a real (non-"0000") password.
    public sealed class CompleteProfileRequest
    {
        public string FullName { get; set; } = "";
        public string JobTitle { get; set; } = "";
        public string Company { get; set; } = "";
        public string NewPassword { get; set; } = "";
    }
}
