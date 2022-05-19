namespace UnifiedLearningSystem.Application.Shared.Security
{
    internal interface ITokenService
    {
        public Task<bool> ValidateTokenAsync(string token);
        public Task<string> GenerateTokenAsync();
    }
}
