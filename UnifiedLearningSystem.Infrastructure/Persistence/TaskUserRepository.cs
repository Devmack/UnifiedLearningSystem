using Microsoft.EntityFrameworkCore;
using UnifiedLearningSystem.Application.Shared.Repository;
using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Infrastructure.Persistence
{
    public class TaskUserRepository : ITaskUserRepository
    {
        private readonly UnifiedLearningSystemContext context;

        public TaskUserRepository(UnifiedLearningSystemContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(TaskUser task)
        {
            await context.UserTasks.AddAsync(task);
            await context.SaveChangesAsync();
        }

        public Task DeleteAsync(TaskUser task)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TaskUser>> GetAllAsync()
        {
            return await context.UserTasks.ToListAsync();
        }

        public async Task<TaskUser> GetSingleAsync(Guid id)
        {
            return await context.UserTasks.FirstAsync(el => el.AggregateID == id);
        }

        public Task<ICollection<TaskUser>> GetSubsetBasedOnAsync(Func<TaskUser, bool> subsetPredicate)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TaskUser task)
        {
            context.UserTasks.Update(task);
            await context.SaveChangesAsync();
        }
    }
}
