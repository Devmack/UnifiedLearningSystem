namespace UnifiedLearningSystem.Domain.Exceptions.Task
{
    internal class MissingCodeStarterException : LearningSystemException
    {
        public MissingCodeStarterException(string msg) : base(msg)
        {
        }
    }
}
