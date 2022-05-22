using UnifiedLearningSystem.Application.DTOs.LearningTask;
using UnifiedLearningSystem.Application.DTOs.Lesson;
using UnifiedLearningSystem.Domain.Entities;
using UnifiedLearningSystem.Domain.Factories;

namespace UnifiedLearningSystem.Application.Mappers
{
    public class LearningLessonMapper : ILearningCoreMapper<LearningLessonReadDTO, LearningLesson>
    {
        private readonly ILearningCoreMapper<LearningTask, LearningTaskCreateDTO> taskMapper;

        public LearningLessonMapper(ILearningCoreMapper<LearningTask, LearningTaskCreateDTO> taskMapper)
        {
            this.taskMapper = taskMapper;
        }

        public LearningLessonReadDTO ConvertFrom(LearningLesson readDto)
        {
            List<LearningTaskCreateDTO> collectionOfMappedTasks = new ();

            readDto.Tasks.ToList().ForEach(task => collectionOfMappedTasks.Add(taskMapper.ConvertFrom(task)));

            return new LearningLessonReadDTO()
            {
                Id = readDto.AggregateID,
                Title = readDto.Title,
                Tasks = collectionOfMappedTasks
            };
        }

        public LearningLesson ConvertFrom(LearningLessonReadDTO readDto)
        {
            List<LearningTask> collectionOfMappedTasks = new();
            if (readDto.Tasks.Any())
            {
                readDto.Tasks.ToList().ForEach(task => collectionOfMappedTasks.Add(taskMapper.ConvertFrom(task)));
            }
            return LearningLessonFactory.Build(readDto.Title, collectionOfMappedTasks);
        }
    }
}
