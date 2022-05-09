﻿using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Domain.Repository
{
    public interface ILessonRepository
    {
        public Task<ICollection<LearningTask>> GetAllAsync();
        public Task<ICollection<LearningTask>> GetSubsetBasedOnAsync(Func<LearningTask, bool> subsetPredicate);
        public Task<LearningTask> GetSingleAsync(Guid id);
        public Task<bool> AddAsync(LearningTask task);
        public Task<bool> DeleteAsync(LearningTask task);
        public Task<bool> UpdateAsync(LearningTask task);

    }
}
