using UnifiedLearningSystem.Application.DTOs.LearningTask;
using UnifiedLearningSystem.Domain.Entities;
using UnifiedLearningSystem.Domain.Factories;

namespace UnifiedLearningSystem.Application.Mappers
{
    public class LearningCoreMapper : ILearningCoreMapper<LearningTask, LearningTaskCreateDTO>
    {
        public LearningTask ConvertFrom(LearningTaskCreateDTO createDTO) => LearningTaskFactory.Build(createDTO._taskTitle, createDTO._taskDescription, createDTO.codeStarter);

        public LearningTaskCreateDTO ConvertFrom(LearningTask createDTO)
        {
            return new(createDTO.TaskTitle, createDTO.TaskDescription, createDTO.TaskCodeStarter);
        }
    }
}
