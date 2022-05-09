namespace UnifiedLearningSystem.Domain.DomainEvents
{
    public class LearningTaskCreated : IDomainEvent
    {
        public DateTime CreationTime { get; init; }
        public string EventDescription { get; init; }

        public LearningTaskCreated()
        {
            EventDescription = "Learning task created";
            CreationTime = DateTime.Now;
        }
    }
}
