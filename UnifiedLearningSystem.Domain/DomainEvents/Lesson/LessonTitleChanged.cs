namespace UnifiedLearningSystem.Domain.DomainEvents.Lesson
{
    public record LessonTitleChanged : IDomainEvent
    {
        public string EventDescription { get; init; }
        public DateTime CreationTime { get; init; }

        public LessonTitleChanged(string newTitle)
        {
            EventDescription = $"Lesson title changed to {newTitle}";
            CreationTime = DateTime.Now;
        }
    }
}
