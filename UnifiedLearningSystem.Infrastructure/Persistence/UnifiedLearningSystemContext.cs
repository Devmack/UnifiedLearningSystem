using Microsoft.EntityFrameworkCore;
using UnifiedLearningSystem.Application.Shared.Context;
using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Infrastructure.Persistence
{
    public class UnifiedLearningSystemContext : DbContext, IDatabaseContext
    {
        public DbSet<LearningLesson> Lessons { get; set; }
        public DbSet<LearningTask> LearningTasks { get; set; }

        public UnifiedLearningSystemContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LearningLesson>().HasKey(lesson => lesson.AggregateID);
            modelBuilder.Entity<LearningLesson>().HasMany(lesson => lesson.Tasks);
            modelBuilder.Entity<LearningLesson>().OwnsOne(lesson => lesson.Title);

            modelBuilder.Entity<LearningTask>().HasKey(task => task.AggregateID);
            modelBuilder.Entity<LearningTask>().OwnsOne(task => task.TaskTitle);
            modelBuilder.Entity<LearningTask>().OwnsOne(task => task.TaskDescription);
        }

    }
}
