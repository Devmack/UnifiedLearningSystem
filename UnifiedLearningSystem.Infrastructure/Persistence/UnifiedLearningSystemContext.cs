using Microsoft.EntityFrameworkCore;
using UnifiedLearningSystem.Application.Shared.Context;
using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Infrastructure.Persistence
{
    public class UnifiedLearningSystemContext : DbContext, IDatabaseContext
    {
        public DbSet<LearningLesson> Lessons { get; set; }
        public DbSet<LearningTask> LearningTasks { get; set; }
        public DbSet<TaskUser> UserTasks { get; set; }

        public UnifiedLearningSystemContext(DbContextOptions<UnifiedLearningSystemContext> options) : base(options) {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LearningLesson>().HasKey(lesson => lesson.AggregateID);
            modelBuilder.Entity<LearningLesson>().HasMany(lesson => lesson.Tasks);
            modelBuilder.Entity<LearningLesson>().OwnsOne(lesson => lesson.Title);

            modelBuilder.Entity<LearningTask>().HasKey(task => task.AggregateID);
            modelBuilder.Entity<LearningTask>().OwnsOne(task => task.TaskTitle);
            modelBuilder.Entity<LearningTask>().OwnsOne(task => task.TaskDescription);
            modelBuilder.Entity<LearningTask>().OwnsOne(task => task.TaskCodeStarter);

            modelBuilder.Entity<TaskUser>().HasKey(taskUser => taskUser.AggregateID);
            modelBuilder.Entity<TaskUser>().OwnsOne(taskUser => taskUser.RepositoriumLink);
            modelBuilder.Entity<TaskUser>().OwnsMany(taskUser => taskUser.TaskUserReviews);
        }

    }
}
