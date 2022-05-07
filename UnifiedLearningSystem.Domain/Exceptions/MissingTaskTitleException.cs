namespace UnifiedLearningSystem.Domain.Exceptions
{
    internal class MissingTaskTitleException : LearningSystemException
    {
        public MissingTaskTitleException(string msg) : base("Entity cannot be created due to empty title")
        {
        }
    }
}
