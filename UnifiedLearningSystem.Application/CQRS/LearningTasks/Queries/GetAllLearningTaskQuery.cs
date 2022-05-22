using MediatR;
using UnifiedLearningSystem.Application.DTOs.LearningTask;
using UnifiedLearningSystem.Application.Mappers;
using UnifiedLearningSystem.Application.Shared.Repository;
using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Application.CQRS.LearningTasks
{
    public class GetAllLearningTaskQuery : IRequest<List<LearningTaskCreateDTO>>
    {

    }

    public class GetAllLearningTaskQueryHandler : IRequestHandler<GetAllLearningTaskQuery, List<LearningTaskCreateDTO>>
    {
        private readonly ILearningTaskRepository lessonRepository;
        private readonly ILearningCoreMapper<LearningTask, LearningTaskCreateDTO> mapper;

        public GetAllLearningTaskQueryHandler(ILearningTaskRepository lessonRepository, ILearningCoreMapper<LearningTask, LearningTaskCreateDTO> mapper)
        {
            this.lessonRepository = lessonRepository;
            this.mapper = mapper;
        }
        public async Task<List<LearningTaskCreateDTO>> Handle(GetAllLearningTaskQuery request, CancellationToken cancellationToken)
        {
            List<LearningTask> allTasks = await lessonRepository.GetAllAsync() as List<LearningTask>;
            var mappedTasks = new List<LearningTaskCreateDTO>();

            allTasks.ForEach(task => mappedTasks.Add(mapper.ConvertFrom(task)));
            return mappedTasks;
        }
    }
}
