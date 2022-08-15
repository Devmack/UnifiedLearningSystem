using UnifiedLearningSystem.Domain.Exceptions.Task;

namespace UnifiedLearningSystem.Domain.ValueObjects.Task
{
    public class TaskImageHeader
    {
        public string Value { get; private set; }

        public TaskImageHeader()
        {

        }

        public TaskImageHeader(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new MissingImageHeaderException("Image header cannot be empty!");
            }
            Value = value;
        }

        public static implicit operator string(TaskImageHeader imageLocation) => imageLocation.Value;

        public static implicit operator TaskImageHeader(string imageLocation) => new(imageLocation);
    }
}
