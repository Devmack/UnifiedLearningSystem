using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnifiedLearningSystem.Application.CQRS.Lessons.Commands;
using UnifiedLearningSystem.Application.CQRS.Lessons.Queries;
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
        [Route("lesson/new")]
        public async Task<ActionResult> CreateNewLesson(LearningLessonCreateDTO lessonCreateDTO)
        {
            return Ok(await mediatR.Send(new CreateNewLessonCommand(lessonCreateDTO)));
        }

        [HttpGet]
        [Route("lessons")]
        public async Task<ActionResult> GetAllLessons()
        {
            return Ok(await mediatR.Send(new GetAllLessonsQuery()));
        }

        [HttpPut]
        [Route("lesson/update")]
        public async Task<ActionResult> CreateNewLesson(AddTaskToLessonDTO lessonUpdateDTO)
        {
            return Ok(await mediatR.Send(new AddTaskToLessonCommand(lessonUpdateDTO)));
        }
    }
}
