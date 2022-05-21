using MediatR;
using UnifiedLearningSystem.Application.DTOs.Identity;
using UnifiedLearningSystem.Application.Shared.Identity;

namespace UnifiedLearningSystem.Application.CQRS.Identity.Commands
{
    public class RegisterUserCommand : IRequest<bool>
    {
        public CredentialsContainerDTO CredentialsContainerDTO { get; set; }

        public RegisterUserCommand(CredentialsContainerDTO credentialsContainerDTO)
        {
            CredentialsContainerDTO = credentialsContainerDTO;
        }
    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IIdentityService identityService;

        public RegisterUserCommandHandler(IIdentityService identityService)
        {
            this.identityService = identityService;
        }
        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await identityService.RegisterAsync(request.CredentialsContainerDTO);
        }


    }
}
