namespace UnifiedLearningSystem.Domain.ValueObjects
{
    public record TaskTitle
    {
        public string Value { get; private set; }

        public TaskTitle()
        {

        }

        public TaskTitle(string value)
        {   
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new MissingTaskTitleException("Title cannot be empty");
            }
            Value = value;
        }

        public static implicit operator string(TaskTitle title) => title.Value; 

        public static implicit operator TaskTitle(string title) => new (title);  
    }
}
