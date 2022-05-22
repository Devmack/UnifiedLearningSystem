using Microsoft.AspNetCore.Identity;
using UnifiedLearningSystem.Application.DTOs.Identity;

namespace UnifiedLearningSystem.Application.Shared.Identity
{
    public interface IIdentityService
    {
        public Task<IdentityUser<Guid>> LoginAsync(CredentialsContainerDTO credentials);
        public Task<bool> RegisterAsync(CredentialsContainerDTO credentials);
        public Task<IdentityUser<Guid>> GetUserAsync(Guid id);
    }
}
