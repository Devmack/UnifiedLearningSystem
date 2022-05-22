using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Application.Shared.Repository
{
    public interface ITaskUserRepository
    {
        public Task<ICollection<TaskUser>> GetAllAsync();
        public Task<ICollection<TaskUser>> GetSubsetBasedOnAsync(Func<TaskUser, bool> subsetPredicate);
        public Task<TaskUser> GetSingleAsync(Guid id);
        public Task AddAsync(TaskUser task);
        public Task DeleteAsync(TaskUser task);
        public Task UpdateAsync(TaskUser task);

    }
}
