using UnifiedLearningSystem.Application.DTOs.TaskUser;
using UnifiedLearningSystem.Domain.Entities;
using UnifiedLearningSystem.Domain.Factories;
using UnifiedLearningSystem.Domain.ValueObjects.TaskUser;

namespace UnifiedLearningSystem.Application.Mappers
{
    public class LearningOwnerCreateMapper : ILearningCoreMapper<TaskUserCreateDTO, TaskUser>
    {
        public TaskUserCreateDTO ConvertFrom(TaskUser createDTO)
        {
            return new TaskUserCreateDTO()
            {
                RepositoriumLink = createDTO.RepositoriumLink,
                TaskOwnerUserID = createDTO.TaskOwnerUserID,
            };
        }

        public TaskUser ConvertFrom(TaskUserCreateDTO createDTO)
        {
            return TaskUserFactory
                .Build(createDTO.TaskOwnerUserID, Guid.NewGuid(), createDTO.RepositoriumLink, new List<TaskReview>());
        }
    }
}
