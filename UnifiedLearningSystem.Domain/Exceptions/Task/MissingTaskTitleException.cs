namespace UnifiedLearningSystem.Domain.Exceptions
{
    public class MissingTaskTitleException : LearningSystemException
    {
        public MissingTaskTitleException(string msg) : base("Entity cannot be created due to empty title")
        {
        }
    }
}
