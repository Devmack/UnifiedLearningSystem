using MediatR;
using Microsoft.AspNetCore.Identity;

namespace UnifiedLearningSystem.Application.CQRS.Identity.Commands
{
    public class AssignRoleToUserCommand : IRequest<bool>
    {
        public string UserName{ get; set; }
        public string RoleName{ get; set; }

        public AssignRoleToUserCommand(string userName, string roleName)
        {
            UserName = userName;
            RoleName = roleName;
        }
    }

    public class AssignRoleToRoleCommandHandler : IRequestHandler<AssignRoleToUserCommand, bool>
    {
        private readonly UserManager<IdentityUser<Guid>> userManager;

        public AssignRoleToRoleCommandHandler(UserManager<IdentityUser<Guid>> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<bool> Handle(AssignRoleToUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.UserName);

            var addOpResult = await userManager.AddToRoleAsync(user, request.RoleName);
            return addOpResult.Succeeded;
        }
    }
}
