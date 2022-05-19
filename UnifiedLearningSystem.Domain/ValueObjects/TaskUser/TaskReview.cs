using UnifiedLearningSystem.Domain.Exceptions.TaskUser;

namespace UnifiedLearningSystem.Domain.ValueObjects.TaskUser
{
    public record TaskReview
    {
        public string Value { get; set; }

        public TaskReview()
        {

        }

        public TaskReview(string value)
        {   
            if (string.IsNullOrEmpty(value))
            {
                throw new MissingReviewException("Review is required");
            }
            Value = value;
        }

        public static implicit operator string(TaskReview review) => review.Value;
        public static implicit operator TaskReview(string value) => new TaskReview(value);
    }
}
