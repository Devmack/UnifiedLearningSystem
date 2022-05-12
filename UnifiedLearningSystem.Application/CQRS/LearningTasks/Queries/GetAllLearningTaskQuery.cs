using MediatR;
using UnifiedLearningSystem.Application.DTOs.LearningTask;
using UnifiedLearningSystem.Application.Mappers;
using UnifiedLearningSystem.Application.Shared.Repository;
using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Application.CQRS.LearningTasks
{
    public class GetAllLearningTaskQuery : IRequest<List<LearningTaskReadDTO>>
    {

    }

    public class GetAllLearningTaskQueryHandler : IRequestHandler<GetAllLearningTaskQuery, List<LearningTaskReadDTO>>
    {
        private readonly ILearningTaskRepository lessonRepository;
        private readonly ILearningCoreMapper<LearningTask, LearningTaskReadDTO> mapper;

        public GetAllLearningTaskQueryHandler(ILearningTaskRepository lessonRepository, ILearningCoreMapper<LearningTask, LearningTaskReadDTO> mapper)
        {
            this.lessonRepository = lessonRepository;
            this.mapper = mapper;
        }
        public async Task<List<LearningTaskReadDTO>> Handle(GetAllLearningTaskQuery request, CancellationToken cancellationToken)
        {
            List<LearningTask> allTasks = await lessonRepository.GetAllAsync() as List<LearningTask>;
            var mappedTasks = new List<LearningTaskReadDTO>();

            allTasks.ForEach(task => mappedTasks.Add(mapper.ConvertFrom(task)));
            return mappedTasks;
        }
    }
}
