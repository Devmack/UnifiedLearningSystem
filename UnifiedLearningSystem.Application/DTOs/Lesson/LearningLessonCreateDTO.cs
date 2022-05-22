using UnifiedLearningSystem.Application.DTOs.LearningTask;
using UnifiedLearningSystem.Domain.ValueObjects.Lesson;

namespace UnifiedLearningSystem.Application.DTOs.Lesson
{
    public record LearningLessonCreateDTO
    {
        public LessonTitle Title { get; set; }
        public ICollection<LearningTaskCreateDTO> Tasks { get; set; }
    }
    
}
