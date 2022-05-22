using MediatR;
using UnifiedLearningSystem.Application.DTOs.Identity;
using UnifiedLearningSystem.Application.Shared.Identity;
using UnifiedLearningSystem.Application.Shared.Security;

namespace UnifiedLearningSystem.Application.CQRS.Identity.Commands
{
    public class LoginUserCommand : IRequest<string>
    {
        public CredentialsContainerDTO LoginCredentialDto { get; set; }

        public LoginUserCommand(CredentialsContainerDTO loginCredentialDto)
        {
            LoginCredentialDto = loginCredentialDto;
        }
    }

    public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IIdentityService identityService;
        private readonly ITokenService tokenService;

        public LoginUserHandler(IIdentityService identityService, ITokenService tokenService)
        {
            this.identityService = identityService;
            this.tokenService = tokenService;
        }
        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var loginOperation = await identityService.LoginAsync(request.LoginCredentialDto);
            string token = string.Empty;

            if (loginOperation != null)
            {
                token = await tokenService.GenerateTokenAsync(loginOperation);
            }
            return token;
        }


    }
}
