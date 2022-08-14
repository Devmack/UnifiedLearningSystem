using UnifiedLearningSystem.Domain.Exceptions.Task;

namespace UnifiedLearningSystem.Domain.ValueObjects.Task
{
    public class TaskCodeStarter
    {
        public string Value { get; private set; }

        public TaskCodeStarter()
        {

        }

        public TaskCodeStarter(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new MissingCodeStarterException("Code starter cannot be empty!");
            }
            Value = value;
        }

        public static implicit operator string(TaskCodeStarter codeStarter) => codeStarter.Value;

        public static implicit operator TaskCodeStarter(string codeStarter) => new(codeStarter);
    }
}
