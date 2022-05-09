using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Domain.DomainEvents.Lesson
{
    public class NewTaskAddedEvent : IDomainEvent
    {
        public string EventDescription { get; init; }
        public DateTime CreationTime { get; init; }

        public NewTaskAddedEvent(LearningTask newTask)
        {
            EventDescription = $"New Task added to lesson = {newTask}";
            CreationTime = DateTime.Now;
        }
    }
}
