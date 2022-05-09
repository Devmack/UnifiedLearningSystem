using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Domain.DomainEvents
{
    public record LearningTaskCreatedEvent : IDomainEvent
    {
        public DateTime CreationTime { get; init; }
        public string EventDescription { get; init; }

        public LearningTaskCreatedEvent(LearningTask task)
        {
            EventDescription = $"Learning task created = {task}";
            CreationTime = DateTime.Now;
        }
    }
}
