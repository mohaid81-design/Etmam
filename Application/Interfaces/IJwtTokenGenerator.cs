using Core;

namespace Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        (string Token, DateTime ExpiresAtUtc) Generate(UsersList user);
    }
}
