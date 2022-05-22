using UnifiedLearningSystem.Application.Shared.Repository;

namespace UnifiedLearningSystem.Infrastructure.Persistence
{
    public class LearningUnitOfWork : IUnitOfWork, IDisposable
    {
        public ILearningTaskRepository LearningTaskRepository { get; set; }
        public ITaskUserRepository TaskUserRepository { get; set; }

        private readonly UnifiedLearningSystemContext context;

        public LearningUnitOfWork(ILearningTaskRepository learningTaskRepository, ITaskUserRepository taskUserRepository, UnifiedLearningSystemContext context)
        {
            LearningTaskRepository = learningTaskRepository;
            TaskUserRepository = taskUserRepository;
            this.context = context;
        }

        public void BeginTransaction() => context.Database.BeginTransaction();

        public void SaveChanges() => context.SaveChanges();

        public void Commit() => context.Database.CommitTransaction();

        public void Rollback() => context.Database.RollbackTransaction();

        public void Dispose() => context.Dispose();
    }
}
