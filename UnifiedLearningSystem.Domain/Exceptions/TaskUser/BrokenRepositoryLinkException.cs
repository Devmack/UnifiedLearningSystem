namespace UnifiedLearningSystem.Domain.Exceptions.TaskUser
{
    public class BrokenRepositoryLinkException : LearningSystemException
    {
        public BrokenRepositoryLinkException(string msg) : base(msg)
        {
        }
    }
}
