namespace UnifiedLearningSystem.Domain.ValueObjects
{
    public record TaskDescription
    {
        public string Value { get; private set; }

        public TaskDescription()
        {

        }

        public TaskDescription(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new MissingTaskDescriptionException("Description cannot be empty!");
            }
            Value = value;
        }

        public static implicit operator string(TaskDescription description) => description.Value;

        public static implicit operator TaskDescription(string description) => new(description);
    }
}
