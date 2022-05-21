using Microsoft.AspNetCore.Identity;
using UnifiedLearningSystem.Application.DTOs.Identity;
using UnifiedLearningSystem.Application.Shared.Identity;

namespace UnifiedLearningSystem.Infrastructure.Identity
{
    public class LearningIdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        private readonly SignInManager<IdentityUser<Guid>> _signInManager;

        public LearningIdentityService(UserManager<IdentityUser<Guid>> userManager, SignInManager<IdentityUser<Guid>> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityUser<Guid>> GetUserAsync(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
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
