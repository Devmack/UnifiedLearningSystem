namespace UnifiedLearningSystem.Domain.DomainEvents
{
    public record LearningTaskTitleChangedEvent : IDomainEvent
    {
        public DateTime CreationTime { get; init; }
        public string EventDescription { get; init; }

        public LearningTaskTitleChangedEvent(string newValue)
        {
            EventDescription = $"Learning task title changed to {newValue}";
            CreationTime = DateTime.Now;
        }
    }
}

