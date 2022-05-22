namespace UnifiedLearningSystem.Application.Shared.Security
{
    public interface ITokenService
    {
        public Task<bool> ValidateTokenAsync(string token);
        public Task<string> GenerateTokenAsync();
    }
}
