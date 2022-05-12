using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnifiedLearningSystem.Application.CQRS.LearningTasks;
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
        public async Task<ActionResult<List<LearningTaskReadDTO>>> GetAllTasks()
        {
            return Ok(await mediatR.Send(new GetAllLearningTaskQuery()));
        }
    }
}
