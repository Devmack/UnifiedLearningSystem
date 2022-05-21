using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnifiedLearningSystem.Application.CQRS.Identity.Commands;
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
    }
}
