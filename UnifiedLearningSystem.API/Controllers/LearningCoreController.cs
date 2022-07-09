using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnifiedLearningSystem.Application.CQRS.LearningTasks;
using UnifiedLearningSystem.Application.CQRS.LearningTasks.Commands;
using UnifiedLearningSystem.Application.DTOs.LearningTask;

namespace UnifiedLearningSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningCoreController : ControllerBase
    {
        private readonly IMediator mediatR;

        public LearningCoreController(IMediator mediatR)
        {
            this.mediatR = mediatR;
        }

        [HttpGet]
        [Route("tasks")]
        public async Task<ActionResult<List<LearningTaskCreateDTO>>> GetAllTasks()
        {
            return Ok(await mediatR.Send(new GetAllLearningTaskQuery()));
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
