using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnifiedLearningSystem.Application.CQRS.TaskUser.Commands;
using UnifiedLearningSystem.Application.CQRS.TaskUser.Queries;
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

        [HttpGet]
        [Route("reviews/{id}")]
        public async Task<ActionResult> CreateNewTask(Guid id)
        {
            return Ok(await mediatR.Send(new GetAllSolutionsOfUserQuery(id)));
        }


        [HttpPost]
        [Route("userTask")]
        public async Task<ActionResult> CreateNewTask(TaskUserCreateDTO taskUserCreateDTO)
        {
            return Ok(await mediatR.Send(new SendSolutionToReviewCommand(taskUserCreateDTO)));
        }

        [HttpPost]
        [Route("review")]
        public async Task<ActionResult> AddReview(Guid id, string reviewDescription)
        {
            return Ok(await mediatR.Send(new ReviewSolutionCommand(id, reviewDescription)));
        }
    }
}
