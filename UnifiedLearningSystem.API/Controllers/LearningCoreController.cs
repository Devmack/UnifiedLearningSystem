using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnifiedLearningSystem.Application.CQRS.LearningTasks;
using UnifiedLearningSystem.Application.CQRS.LearningTasks.Commands;
using UnifiedLearningSystem.Application.CQRS.LearningTasks.Queries;
using UnifiedLearningSystem.Application.DTOs.LearningTask;
using UnifiedLearningSystem.Application.Shared.QueryHelper;

namespace UnifiedLearningSystem.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "student")]
    [Route("api/[controller]")]
    [ApiController]
    public class LearningCoreController : ControllerBase
    {
        private readonly IMediator mediatR;

        public LearningCoreController(IMediator mediatR)
        {
            this.mediatR = mediatR;
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any)]
        [HttpGet]
        [Route("tasks")]
        public async Task<ActionResult<List<LearningTaskCreateDTO>>> GetAllTasks()
        {
            return Ok(await mediatR.Send(new GetAllLearningTaskQuery()));
        }

        [HttpGet]
        [Route("task/{id}")]
        public async Task<ActionResult<LearningTaskCreateDTO>> GetSingleTask(Guid id)
        {
            return Ok(await mediatR.Send(new GetSingleTaskQuery(id)));
        }
            
        [AllowAnonymous]
        [HttpGet]
        [Route("tasks/pages")]
        public async Task<ActionResult<LearningTaskPaginatedResultDTO>> GetAllTaskPaginated([FromQuery] PageQuery queryPage)
        {
            var result = await mediatR.Send(new GetAllLearningTaskPaginated(queryPage));
            return Ok(result);
        }

        [HttpPost]
        [Route("task")]
        public async Task<ActionResult> CreateNewTask(CreateNewTaskCommand newTaskCommand)
        {
            return Ok(await mediatR.Send(newTaskCommand));
        }

        [HttpDelete]
        [Route("tasks/{id}")]
        public async Task<ActionResult> DeleteTask(Guid id)
        {
            return Ok(await mediatR.Send(new DeleteTaskCommand(id)));
        }
    }
}
