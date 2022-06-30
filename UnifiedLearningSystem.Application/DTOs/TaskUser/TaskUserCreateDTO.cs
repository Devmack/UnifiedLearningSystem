using UnifiedLearningSystem.Domain.ValueObjects.TaskUser;

namespace UnifiedLearningSystem.Application.DTOs.TaskUser
{
    public class TaskUserCreateDTO
    {
        public Guid TaskOwnerUserID { get; set; }
        public Guid TaskID { get; set; }
        public TaskRepositoriumLink RepositoriumLink { get; set; }
    }
}
