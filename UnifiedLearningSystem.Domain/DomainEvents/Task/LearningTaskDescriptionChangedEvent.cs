namespace UnifiedLearningSystem.Domain.DomainEvents
{
    public record LearningTaskDescriptionChangedEvent : IDomainEvent
    {
        public DateTime CreationTime { get; init; }
        public string EventDescription { get; init; }

        public LearningTaskDescriptionChangedEvent(string newDescription)
        {
            EventDescription = $"Learning task description changed to {newDescription}";
            CreationTime = DateTime.Now;
        }
    }
}


