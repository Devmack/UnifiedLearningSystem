namespace UnifiedLearningSystem.Domain.Exceptions.TaskUser
{
    public class MissingReviewException : LearningSystemException
    {
        public MissingReviewException(string msg) : base(msg)
        {
        }
    }
}
