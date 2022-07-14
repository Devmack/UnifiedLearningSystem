using MediatR;
using Microsoft.AspNetCore.Identity;

namespace UnifiedLearningSystem.Application.CQRS.Identity.Commands
{
    public class CreateNewRoleCommand : IRequest<bool>
    {
        public string RoleName { get; set; }

        public CreateNewRoleCommand(string roleName)
        {
            RoleName = roleName;
        }
    }

    public class CreateNewRoleCommandHandler : IRequestHandler<CreateNewRoleCommand, bool>
    {
        private readonly RoleManager<IdentityRole<Guid>> roleManager;

        public CreateNewRoleCommandHandler(RoleManager<IdentityRole<Guid>> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<bool> Handle(CreateNewRoleCommand request, CancellationToken cancellationToken)
        {
            var addRoleResult = await this.roleManager.CreateAsync(new IdentityRole<Guid>() { Name = request.RoleName});
            return addRoleResult.Succeeded;
        }
    }
}
