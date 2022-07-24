using Microsoft.EntityFrameworkCore;
using UnifiedLearningSystem.Application.Shared.Repository;
using UnifiedLearningSystem.CommonAbstraction.Interfaces;
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

        public async Task DeleteAsync(TaskUser task)
        {
            context.UserTasks.Remove(task);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<TaskUser>> GetAllAsync()
        {
            return await context.UserTasks.ToListAsync();
        }

        public async Task<ICollection<TaskUser>> GetAllAsync(IPageQuery queryPage)
        {
            return await context.UserTasks.Take(queryPage.MaxElements).Skip(queryPage.CurrentPage - 1 * queryPage.ElementsPerPage).ToListAsync();
        }

        public async Task<TaskUser> GetSingleAsync(Guid id)
        {
            return await context.UserTasks.FirstAsync(el => el.AggregateID == id);
        }

        public async Task<ICollection<TaskUser>> GetSubsetBasedOnAsync(Func<TaskUser, bool> subsetPredicate)
        {
            var generalCollection = await context.UserTasks.ToListAsync();
            return generalCollection.Where(subsetPredicate).ToList();
        }

        public async Task UpdateAsync(TaskUser task)
        {
            context.UserTasks.Update(task);
            await context.SaveChangesAsync();
        }
    }
}
