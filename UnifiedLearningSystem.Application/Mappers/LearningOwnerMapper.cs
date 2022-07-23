using UnifiedLearningSystem.Application.DTOs.TaskUser;
using UnifiedLearningSystem.Domain.Entities;
using UnifiedLearningSystem.Domain.Factories;

namespace UnifiedLearningSystem.Application.Mappers
{
    public class LearningOwnerMapper : ILearningCoreMapper<TaskUserReadDTO, TaskUser>
    {
        public TaskUserReadDTO ConvertFrom(TaskUser createDTO)
        {
            return new TaskUserReadDTO()
            {
                TaskID = createDTO.TaskID,
                TaskOwnerUserID = createDTO.TaskOwnerUserID,
                RepositoriumLink = createDTO.RepositoriumLink,
                TaskUserReviews = createDTO.TaskUserReviews,
                TimeOfSubmission = createDTO.TimeOfSubmission
            };
        }

        public TaskUser ConvertFrom(TaskUserReadDTO createDTO)
        {
            return TaskUserFactory
                .Build(createDTO.TaskOwnerUserID, createDTO.TaskID, createDTO.RepositoriumLink, createDTO.TaskUserReviews, createDTO.TimeOfSubmission);
        }
    }
}
