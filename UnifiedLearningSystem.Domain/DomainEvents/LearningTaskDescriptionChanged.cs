namespace UnifiedLearningSystem.Domain.DomainEvents
{
    public class LearningTaskDescriptionChanged : IDomainEvent
    {
        public DateTime CreationTime { get; init; }
        public string EventDescription { get; init; }

        public LearningTaskDescriptionChanged()
        {
            EventDescription = "Learning task description changed";
            CreationTime = DateTime.Now;
        }
    }
}


