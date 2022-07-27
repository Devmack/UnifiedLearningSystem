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

        public LearningLesson GetSingle(Guid id)
        {
            return context.Lessons.First(el => el.AggregateID == id);
        }

        public async Task<LearningLesson> GetSingleAsync(Guid id)
        {
            return await context.Lessons.FirstAsync(el => el.AggregateID == id);
        }

        public ICollection<LearningLesson> GetSubsetBasedOn(Func<LearningLesson, bool> subsetPredicate)
        {
            return context.Lessons.Include(el => el.Tasks).Where(subsetPredicate).ToList();
        }

        public Task<ICollection<LearningLesson>> GetSubsetBasedOnAsync(Func<LearningLesson, bool> subsetPredicate)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(LearningLesson lesson)
        {   
            context.Lessons.Update(lesson);
            await context.SaveChangesAsync();
        }
    }
}
