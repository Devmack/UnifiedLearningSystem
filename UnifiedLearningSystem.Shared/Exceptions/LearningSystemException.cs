namespace UnifiedLearningSystem.Shared.Exceptions
{
    public abstract class LearningSystemException : Exception
    {
        protected LearningSystemException(string msg) : base(msg) { }
    }
}
