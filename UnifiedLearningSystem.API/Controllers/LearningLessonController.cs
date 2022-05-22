using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnifiedLearningSystem.Application.CQRS.Lessons.Commands;
using UnifiedLearningSystem.Application.DTOs.Lesson;

namespace UnifiedLearningSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningLessonController : ControllerBase
    {
        private readonly IMediator mediatR;

        public LearningLessonController(IMediator mediatR)
        {
            this.mediatR = mediatR;
        }

        [HttpPost]
        [Route("task")]
        public async Task<ActionResult> CreateNewTask(LearningLessonCreateDTO lessonCreateDTO)
        {
            return Ok(await mediatR.Send(new CreateNewLessonCommand(lessonCreateDTO)));
        }
    }
}
