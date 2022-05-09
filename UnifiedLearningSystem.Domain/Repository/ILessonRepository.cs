using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Domain.Repository
{
    public interface ILessonRepository
    {
        public Task<ICollection<LearningTask>> GetAll();
        public Task<ICollection<LearningTask>> GetSubsetBasedOn(Func<LearningTask, bool> subsetPredicate);
        public Task<LearningTask> GetSingle(Guid id);
        public Task<bool> Add(LearningTask task);
        public Task<bool> Delete(LearningTask task);

    }
}
