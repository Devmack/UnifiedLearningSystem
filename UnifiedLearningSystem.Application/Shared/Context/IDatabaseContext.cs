using Microsoft.EntityFrameworkCore;
using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Application.Shared.Context
{
    public interface IDatabaseContext
    {
        public DbSet<LearningLesson> Lessons { get; set; }
        public DbSet<LearningTask> LearningTasks { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
