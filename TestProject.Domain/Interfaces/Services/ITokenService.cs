using TestProject.Domain.Entities;

namespace TestProject.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        Task<string> GenerateTokenByUser(User user);
    }
}
