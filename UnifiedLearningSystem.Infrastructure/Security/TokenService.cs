using UnifiedLearningSystem.Application.Shared.Security;

namespace UnifiedLearningSystem.Infrastructure.Security
{
    public class TokenService : ITokenService
    {
        public Task<string> GenerateTokenAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateTokenAsync(string token)
        {
            throw new NotImplementedException();
        }
    }
}
