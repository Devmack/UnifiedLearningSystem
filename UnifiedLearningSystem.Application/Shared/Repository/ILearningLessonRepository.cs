using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Application.Shared.Repository
{
    public interface ILearningLessonRepository
    {
        public Task<ICollection<LearningLesson>> GetAllAsync();
        public Task<ICollection<LearningLesson>> GetSubsetBasedOnAsync(Func<LearningLesson, bool> subsetPredicate);
        public ICollection<LearningLesson> GetSubsetBasedOn(Func<LearningLesson, bool> subsetPredicate);
        public Task<LearningLesson> GetSingleAsync(Guid id);
        public LearningLesson GetSingle(Guid id);
        public Task AddAsync(LearningLesson task);
        public Task DeleteAsync(LearningLesson task);
        public Task UpdateAsync(LearningLesson task);
    }
}
