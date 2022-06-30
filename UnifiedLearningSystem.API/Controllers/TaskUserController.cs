using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnifiedLearningSystem.Application.CQRS.TaskUser.Commands;
using UnifiedLearningSystem.Application.DTOs.TaskUser;

namespace UnifiedLearningSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskUserController : ControllerBase
    {
        private readonly IMediator mediatR;

        public TaskUserController(IMediator mediatR)
        {
            this.mediatR = mediatR;
        }

        [HttpPost]
        [Route("userTask")]
        public async Task<ActionResult> CreateNewTask(TaskUserCreateDTO taskUserCreateDTO)
        {
            return Ok(await mediatR.Send(new SendSolutionToReviewCommand(taskUserCreateDTO)));
        }
    }
}
