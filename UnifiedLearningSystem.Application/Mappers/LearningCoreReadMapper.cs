using AutoMapper;
using UnifiedLearningSystem.Application.DTOs.LearningTask;
using UnifiedLearningSystem.Domain.Entities;
using UnifiedLearningSystem.Domain.Factories;

namespace UnifiedLearningSystem.Application.Mappers
{
    public class LearningCoreReadMapper : ILearningCoreMapper<LearningTask, LearningTaskReadDTO>
    {
        public LearningTask ConvertFrom(LearningTaskReadDTO readDTO) => LearningTaskFactory.Build(readDTO._taskTitle, readDTO._taskDescription);

        public LearningTaskReadDTO ConvertFrom(LearningTask readDTO)
        {
            return new(readDTO.AggregateID, readDTO.TaskTitle, readDTO.TaskDescription);
        }
    }
}
