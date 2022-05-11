using AutoMapper;
using UnifiedLearningSystem.Application.DTOs.LearningTask;
using UnifiedLearningSystem.Domain.Entities;
using UnifiedLearningSystem.Domain.Factories;

namespace UnifiedLearningSystem.Application.Mappers
{
    public class LearningCoreReadMapper : ILearningCoreMapper<LearningTask, LearningTaskReadDTO>
    {
        public LearningTask ConvertFrom(LearningTaskReadDTO createDTO) => LearningTaskFactory.Build(createDTO._taskTitle, createDTO._taskDescription);

        public LearningTaskReadDTO ConvertFrom(LearningTask createDTO)
        {
            return new(createDTO.TaskTitle, createDTO.TaskDescription);
        }
    }
}
