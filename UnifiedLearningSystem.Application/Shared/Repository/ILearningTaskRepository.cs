using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Application.Shared.Repository
{
    public interface ILearningTaskRepository
    {
        public Task<List<LearningTask>> GetAllAsync();
        public Task<ICollection<LearningTask>> GetSubsetBasedOnAsync(Func<LearningTask, bool> subsetPredicate);
        public Task<LearningTask> GetSingleAsync(Guid id);
        public Task AddAsync(LearningTask task);
        public Task DeleteAsync(LearningTask task);
        public Task UpdateAsync(LearningTask task);

    }
}
