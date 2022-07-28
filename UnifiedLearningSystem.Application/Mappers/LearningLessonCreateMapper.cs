using UnifiedLearningSystem.Application.DTOs.LearningTask;
using UnifiedLearningSystem.Application.DTOs.Lesson;
using UnifiedLearningSystem.Domain.Entities;
using UnifiedLearningSystem.Domain.Factories;

namespace UnifiedLearningSystem.Application.Mappers
{
    public class LearningLessonCreateMapper : ILearningCoreMapper<LearningLessonCreateDTO, LearningLesson>
    {
        private readonly ILearningCoreMapper<LearningTask, LearningTaskCreateDTO> learningCoreMapper;

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
            };
        }

        public LearningLesson ConvertFrom(LearningLessonCreateDTO createDTO)
        {

            return LearningLessonFactory.Build(createDTO.Title);
        }
    }
}
