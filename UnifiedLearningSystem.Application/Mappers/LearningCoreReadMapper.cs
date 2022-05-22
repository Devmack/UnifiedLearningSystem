using AutoMapper;
using UnifiedLearningSystem.Application.DTOs.LearningTask;
using UnifiedLearningSystem.Domain.Entities;
using UnifiedLearningSystem.Domain.Factories;

namespace UnifiedLearningSystem.Application.Mappers
{
    public class LearningCoreReadMapper : ILearningCoreMapper<LearningTask, LearningTaskCreateDTO>
    {
        public LearningTask ConvertFrom(LearningTaskCreateDTO createDTO) => LearningTaskFactory.Build(createDTO._taskTitle, createDTO._taskDescription);

        public LearningTaskCreateDTO ConvertFrom(LearningTask createDTO)
        {
            return new(createDTO.TaskTitle, createDTO.TaskDescription);
        }
    }
}
