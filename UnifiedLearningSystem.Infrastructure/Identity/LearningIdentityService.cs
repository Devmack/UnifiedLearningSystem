using Microsoft.AspNetCore.Identity;
using UnifiedLearningSystem.Application.DTOs.Identity;
using UnifiedLearningSystem.Application.Shared.Identity;

namespace UnifiedLearningSystem.Infrastructure.Identity
{
    public class LearningIdentityService : IIdentityService
    {
        public Task<IdentityUser<Guid>> GetUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> LoginAsync(CredentialsContainerDTO credentials)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterAsync(CredentialsContainerDTO credentials)
        {
            throw new NotImplementedException();
        }
    }
}
