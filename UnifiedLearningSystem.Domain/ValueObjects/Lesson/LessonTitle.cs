namespace UnifiedLearningSystem.Domain.ValueObjects.Lesson
{
    public record LessonTitle
    {
        public string Value { get; private set; }

        public LessonTitle(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new MissingTaskDescriptionException("Lesson Title cannot be empty!");
            }
            Value = value;
        }

        public static implicit operator string(LessonTitle title) => title.Value;

        public static implicit operator LessonTitle(string title) => new(title);
    }
}
