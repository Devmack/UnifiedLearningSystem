using UnifiedLearningSystem.Domain.DomainEvents;

namespace UnifiedLearningSystem.Domain.Aggregates
{
    public abstract class AggregateRoot
    {
        public Guid AggregateID { get; protected set; }

        private ICollection<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        protected AggregateRoot()
        {
            AggregateID = Guid.NewGuid();
        }

        public void AddEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
