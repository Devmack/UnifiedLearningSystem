using UnifiedLearningSystem.Domain.ValueObjects;

namespace UnifiedLearningSystem.Application.DTOs.LearningTask
{
    public record LearningTaskCreateDTO(TaskTitle _taskTitle, TaskDescription _taskDescription);

}
