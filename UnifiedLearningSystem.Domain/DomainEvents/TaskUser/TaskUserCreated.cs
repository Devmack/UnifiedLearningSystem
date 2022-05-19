namespace UnifiedLearningSystem.Domain.DomainEvents.TaskUser
{
    public class TaskUserCreated : IDomainEvent
    {
        public DateTime CreationTime { get; init; }
        public string EventDescription { get; init; }

        public TaskUserCreated(string newValue)
        {
            EventDescription = $"Task {newValue} linked";
            CreationTime = DateTime.Now;
        }
    }
}
