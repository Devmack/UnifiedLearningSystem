using UnifiedLearningSystem.Domain.Entities;
using UnifiedLearningSystem.Domain.ValueObjects.TaskUser;

namespace UnifiedLearningSystem.Domain.Factories
{
    public static class TaskUserFactory
    {
        public static TaskUser Build(Guid TaskOwnerUserID, Guid TaskID, string RepositoriumLink, List<TaskReview> TaskUserReviews, DateTime time)
        {
            return new TaskUser(TaskOwnerUserID, TaskID, RepositoriumLink, TaskUserReviews, time);
        }
    }
}
