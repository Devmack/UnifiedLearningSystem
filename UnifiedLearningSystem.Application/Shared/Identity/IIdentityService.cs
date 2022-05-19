using Microsoft.AspNet.Identity.EntityFramework;
using UnifiedLearningSystem.Application.DTOs.Identity;

namespace UnifiedLearningSystem.Application.Shared.Identity
{
    public interface IIdentityService
    {
        public Task<bool> LoginAsync(CredentialsContainerDTO credentials);
        public Task<bool> RegisterAsync(CredentialsContainerDTO credentials);
        public Task<IdentityUser> GetUserAsync(Guid id);
    }
}
