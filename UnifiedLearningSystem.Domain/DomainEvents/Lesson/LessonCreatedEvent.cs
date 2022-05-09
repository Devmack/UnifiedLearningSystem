using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Domain.DomainEvents.Lesson
{
    public record LessonCreatedEvent : IDomainEvent
    {
        public string EventDescription { get; init; }
        public DateTime CreationTime { get; init; }

        public LessonCreatedEvent(LearningLesson lesson)
        {
            EventDescription = $"Lesson created {lesson}";
            CreationTime = DateTime.Now;
        }
    }
}
