namespace UnifiedLearningSystem.Domain.Exceptions
{
    internal class MissingTaskDescriptionException : LearningSystemException
    {
        public MissingTaskDescriptionException(string msg) : base(msg)
        {
        }
    }
}
