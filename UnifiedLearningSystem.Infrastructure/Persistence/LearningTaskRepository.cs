using UnifiedLearningSystem.Application.Shared.Repository;
using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Infrastructure.Persistence
{
    internal class LearningTaskRepository : ILearningTaskRepository
    {
        public Task<bool> AddAsync(LearningTask task)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(LearningTask task)
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

        public Task<bool> UpdateAsync(LearningTask task)
        {
            throw new NotImplementedException();
        }
    }
}
