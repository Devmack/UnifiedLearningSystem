namespace UnifiedLearningSystem.Domain.Exceptions.TaskUser
{
    public class MissingLinkRepositoryException : LearningSystemException
    {
        public MissingLinkRepositoryException(string msg) : base(msg)
        {
        }
    }
}
