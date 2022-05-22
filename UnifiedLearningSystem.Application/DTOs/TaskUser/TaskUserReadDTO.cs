using UnifiedLearningSystem.Domain.ValueObjects.TaskUser;

namespace UnifiedLearningSystem.Application.DTOs.TaskUser
{
    public record TaskUserReadDTO
    {
        public Guid TaskOwnerUserID { get; set; }
        public Guid TaskID { get; set; }
        public TaskRepositoriumLink RepositoriumLink { get; set; }
        public List<TaskReview> TaskUserReviews { get; set; }
    }
}
