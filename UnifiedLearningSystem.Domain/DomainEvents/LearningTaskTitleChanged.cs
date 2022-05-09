namespace UnifiedLearningSystem.Domain.DomainEvents
{
    public class LearningTaskTitleChanged : IDomainEvent
    {
        public DateTime CreationTime { get; init; }
        public string EventDescription { get; init; }

        public LearningTaskTitleChanged()
        {
            EventDescription = "Learning task title changed";
            CreationTime = DateTime.Now;
        }
    }
}

