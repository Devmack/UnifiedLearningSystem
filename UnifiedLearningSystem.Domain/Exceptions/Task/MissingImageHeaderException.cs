namespace UnifiedLearningSystem.Domain.Exceptions.Task
{
    public class MissingImageHeaderException : LearningSystemException
    {
        public MissingImageHeaderException(string msg) : base(msg)
        {
        }
    }
}
