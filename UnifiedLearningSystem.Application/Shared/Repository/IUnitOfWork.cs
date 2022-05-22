namespace UnifiedLearningSystem.Application.Shared.Repository
{
    public interface IUnitOfWork
    {
        public ILearningTaskRepository LearningTaskRepository { get; set; }
        public ITaskUserRepository TaskUserRepository { get; set; }

        void BeginTransaction();
        void SaveChanges();
        void Commit();
        void Rollback();

    }
}
