

namespace UnifiedLearningSystem.Domain.DomainEvents.TaskUser
{
    public class TaskReviewAdded : IDomainEvent
    {
        public DateTime CreationTime { get; init; }
        public string EventDescription { get; init; }

        public TaskReviewAdded()
        {
            EventDescription = $"Task review added";
            CreationTime = DateTime.Now;
        }
    }
}
