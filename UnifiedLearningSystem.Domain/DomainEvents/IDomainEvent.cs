namespace UnifiedLearningSystem.Domain.DomainEvents
{
    public interface IDomainEvent
    {
        public string EventDescription { get; init; }
        public DateTime CreationTime { get; init; }
    }
}
