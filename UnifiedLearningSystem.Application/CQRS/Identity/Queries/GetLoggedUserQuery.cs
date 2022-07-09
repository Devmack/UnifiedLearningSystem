using MediatR;
using Microsoft.AspNetCore.Identity;
using UnifiedLearningSystem.Application.Shared.Identity;

namespace UnifiedLearningSystem.Application.CQRS.Identity.Queries
{
    public class GetLoggedUserQuery : IRequest<IdentityUser<Guid>>
    {
        public Guid UserId { get; set; }

        public GetLoggedUserQuery(Guid userId)
        {
            UserId = userId;
        }
    }

    public class GetLoggedUserQueryHandler : IRequestHandler<GetLoggedUserQuery, IdentityUser<Guid>>
    {
        private readonly IIdentityService userManager;

        public GetLoggedUserQueryHandler(IIdentityService _userManager)
        {
            userManager = _userManager;
        }

        public async Task<IdentityUser<Guid>> Handle(GetLoggedUserQuery request, CancellationToken cancellationToken)
        {
            return await userManager.GetUserAsync(request.UserId);
        }
    }
}
