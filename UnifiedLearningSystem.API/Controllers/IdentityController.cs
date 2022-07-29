using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnifiedLearningSystem.Application.CQRS.Identity.Commands;
using UnifiedLearningSystem.Application.CQRS.Identity.Queries;
using UnifiedLearningSystem.Application.DTOs.Identity;

namespace UnifiedLearningSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IMediator mediatR;

        public IdentityController(IMediator mediatR)
        {
            this.mediatR = mediatR;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> CreateNewTask(CredentialsContainerDTO credentials)
        {
            return Ok(await mediatR.Send(new RegisterUserCommand(credentials)));
        }

        [HttpPost]
        [Route("role")]
        public async Task<ActionResult> AddNewRole(string roleName)
        {
            return Ok(await mediatR.Send(new CreateNewRoleCommand(roleName)));
        }

        [HttpPut]
        [Route("user/role")]
        public async Task<ActionResult> AssignRoleToUser(AssignRoleToUserCommand command)
        {
            return Ok(await mediatR.Send(command));
        }

        [HttpPost]
        [Route("login")]
        public async Task<string> Login(CredentialsContainerDTO credentials)
        {
            var result = await mediatR.Send(new LoginUserCommand(credentials));
            return result;
        }

        [HttpGet]
        [Route("user/{id}")]
        public async Task<ActionResult> GetUser(Guid id)
        {
            return Ok(await mediatR.Send(new GetLoggedUserQuery(id)));
        }

    }
}
