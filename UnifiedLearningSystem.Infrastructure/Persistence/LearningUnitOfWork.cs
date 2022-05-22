using UnifiedLearningSystem.Application.Shared.Repository;

namespace UnifiedLearningSystem.Infrastructure.Persistence
{
    public class LearningUnitOfWork : IUnitOfWork, IDisposable
    {
        public ILearningTaskRepository LearningTaskRepository { get; set; }
        public ITaskUserRepository TaskUserRepository { get; set; }
        public ILearningLessonRepository LearningLessonRepository { get; set; }

        private readonly UnifiedLearningSystemContext context;

        public LearningUnitOfWork(ILearningTaskRepository learningTaskRepository, ITaskUserRepository taskUserRepository, UnifiedLearningSystemContext context, ILearningLessonRepository learningLessonRepository)
        {
            LearningTaskRepository = learningTaskRepository;
            TaskUserRepository = taskUserRepository;
            LearningLessonRepository = learningLessonRepository;

            this.context = context;
        }

        public void BeginTransaction() => context.Database.BeginTransaction();

        public void SaveChanges() => context.SaveChanges();

        public void Commit() => context.Database.CommitTransaction();

        public void Rollback() => context.Database.RollbackTransaction();

        public void Dispose() => context.Dispose();
    }
}
