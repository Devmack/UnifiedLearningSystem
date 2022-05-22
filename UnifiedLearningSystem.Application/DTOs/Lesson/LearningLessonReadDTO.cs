using UnifiedLearningSystem.Application.DTOs.LearningTask;
using UnifiedLearningSystem.Domain.ValueObjects.Lesson;

namespace UnifiedLearningSystem.Application.DTOs.Lesson
{
    public record LearningLessonReadDTO
    {
        public Guid Id { get; set; }
        public LessonTitle Title { get; set; }
        public ICollection<LearningTaskCreateDTO> Tasks { get; set; }
    }
}
