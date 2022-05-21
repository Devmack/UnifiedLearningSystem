﻿using Microsoft.AspNetCore.Identity;
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

        public async Task<bool> LoginAsync(CredentialsContainerDTO credentials)
        {
            var user = await _userManager.FindByNameAsync(credentials.login);
            var signInResult = await _signInManager.PasswordSignInAsync(user, credentials.password, false, false);

            return signInResult.Succeeded;
        }

        public async Task<bool> RegisterAsync(CredentialsContainerDTO credentials)
        {
            var newUser = new IdentityUser<Guid>()
            {
                UserName = credentials.login
            };
            var isUserCreated = await _userManager.CreateAsync(newUser);

            if (!isUserCreated.Succeeded) return false;
            
            var registerAction = await _userManager.AddPasswordAsync(newUser, credentials.password);

            return registerAction.Succeeded;
        }
    }
}