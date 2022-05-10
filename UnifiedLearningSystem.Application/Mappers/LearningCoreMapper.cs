using AutoMapper;
using UnifiedLearningSystem.Application.DTOs.LearningTask;
using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Application.Mappers
{
    public class LearningCoreMapper : Profile
    {
        public LearningCoreMapper()
        {
            CreateMap<LearningTask, LearningTaskCreateDTO>().ReverseMap();
        }
    }
}
