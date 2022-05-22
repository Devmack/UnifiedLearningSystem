using Microsoft.EntityFrameworkCore;
using UnifiedLearningSystem.Application.Shared.Repository;
using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Infrastructure.Persistence
{
    public class LearningLessonRepository : ILearningLessonRepository
    {
        private readonly UnifiedLearningSystemContext context;

        public LearningLessonRepository(UnifiedLearningSystemContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(LearningLesson task)
        {
            await context.Lessons.AddAsync(task);
            await context.SaveChangesAsync();
        }

        public Task DeleteAsync(LearningLesson task)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<LearningLesson>> GetAllAsync()
        {
            return await context.Lessons.ToListAsync();
        }

        public Task<LearningLesson> GetSingleAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<LearningLesson>> GetSubsetBasedOnAsync(Func<LearningLesson, bool> subsetPredicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(LearningLesson task)
        {
            throw new NotImplementedException();
        }
    }
}
