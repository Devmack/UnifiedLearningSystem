using UnifiedLearningSystem.Application.Shared.Repository;
using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Infrastructure.Persistence
{
    public class LearningTaskRepository : ILearningTaskRepository
    {
        private readonly UnifiedLearningSystemContext context;

        public LearningTaskRepository(UnifiedLearningSystemContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(LearningTask task)
        {
            await context.LearningTasks.AddAsync(task);
        }

        public Task DeleteAsync(LearningTask task)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<LearningTask>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LearningTask> GetSingleAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<LearningTask>> GetSubsetBasedOnAsync(Func<LearningTask, bool> subsetPredicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(LearningTask task)
        {
            throw new NotImplementedException();
        }
    }
}
