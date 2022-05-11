using Microsoft.EntityFrameworkCore;
using UnifiedLearningSystem.Application.Shared.Context;
using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Infrastructure.Persistence
{
    public class UnifiedLearningSystemContext : DbContext, IDatabaseContext
    {
        public DbSet<LearningLesson> Lessons { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<LearningTask> LearningTasks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
