using Microsoft.EntityFrameworkCore;
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
            await context.SaveChangesAsync();   
        }

        public async Task DeleteAsync(LearningTask task)
        {
            context.LearningTasks.Remove(task);
            await context.SaveChangesAsync();
        }

        public async Task<List<LearningTask>> GetAllAsync()
        {
            return await context.LearningTasks.ToListAsync();
        }

        public async Task<LearningTask> GetSingleAsync(Guid id)
        {
            return await context.LearningTasks.FirstAsync(el => el.AggregateID == id);
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
