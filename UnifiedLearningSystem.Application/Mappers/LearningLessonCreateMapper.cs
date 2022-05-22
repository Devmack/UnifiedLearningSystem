using UnifiedLearningSystem.Application.DTOs.LearningTask;
using UnifiedLearningSystem.Application.DTOs.Lesson;
using UnifiedLearningSystem.Domain.Entities;
using UnifiedLearningSystem.Domain.Factories;

namespace UnifiedLearningSystem.Application.Mappers
{
    public class LearningLessonCreateMapper : ILearningCoreMapper<LearningLessonCreateDTO, LearningLesson>
    {
        private ILearningCoreMapper<LearningTask, LearningTaskCreateDTO> learningCoreMapper;

        public LearningLessonCreateMapper(ILearningCoreMapper<LearningTask, LearningTaskCreateDTO> learningCoreMapper)
        {
            this.learningCoreMapper = learningCoreMapper;
        }

        public LearningLessonCreateDTO ConvertFrom(LearningLesson createDTO)
        {
            List<LearningTaskCreateDTO> collectionOfMappedTasks = new();

            if (createDTO.Tasks.Any())
            {
                createDTO.Tasks.ToList().ForEach(task => collectionOfMappedTasks.Add(learningCoreMapper.ConvertFrom(task)));
            }

            return new LearningLessonCreateDTO()
            {
                Title = createDTO.Title,
                Tasks = collectionOfMappedTasks
            };
        }

        public LearningLesson ConvertFrom(LearningLessonCreateDTO createDTO)
        {
            List<LearningTask> collectionOfMappedTasks = new();
            if (createDTO.Tasks.Any())
            {
                createDTO.Tasks.ToList().ForEach(task => collectionOfMappedTasks.Add(learningCoreMapper.ConvertFrom(task)));
            }
            return LearningLessonFactory.Build(createDTO.Title, collectionOfMappedTasks);
        }
    }
}
