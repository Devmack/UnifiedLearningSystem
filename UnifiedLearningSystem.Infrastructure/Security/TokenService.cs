﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UnifiedLearningSystem.Application.Shared.Security;

namespace UnifiedLearningSystem.Infrastructure.Security
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        private readonly IConfiguration config;

        public TokenService(UserManager<IdentityUser<Guid>> userManager, IConfiguration config)
        {
            _userManager = userManager;
            this.config = config;
        }

        public async Task<string> GenerateTokenAsync(IdentityUser<Guid> user)
        {
            var usrClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            if (roles.Any())
            {
                for (int i = 0; i < roles.Count; i++)
                {
                    roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
                }
            } else
            {
                roles = new List<string>();
            }

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: config["Token:Issuer"],
                audience: config["Token:Audience"],
                claims: new[] { new Claim(JwtRegisteredClaimNames.Sub, user.UserName), new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()) },
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: signingCredentials);

            var stringifiedToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return stringifiedToken;
        }

        public Task<bool> ValidateTokenAsync(string token)
        {
            throw new NotImplementedException();
        }
    }
}
