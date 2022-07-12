using MediatR;
using UnifiedLearningSystem.Application.DTOs.LearningTask;
using UnifiedLearningSystem.Application.Mappers;
using UnifiedLearningSystem.Application.Shared.Repository;
using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Application.CQRS.LearningTasks.Queries
{
    public class GetSingleTaskQuery : IRequest<LearningTaskReadDTO>
    {
        public GetSingleTaskQuery(Guid targetId)
        {
            TargetId = targetId;
        }

        public Guid TargetId { get; set; }
    }
    
    public class GetSingleTaskQueryHandler : IRequestHandler<GetSingleTaskQuery, LearningTaskReadDTO>
    {
        private readonly IUnitOfWork lessonRepository;
        private readonly ILearningCoreMapper<LearningTask, LearningTaskReadDTO> mapper;

        public GetSingleTaskQueryHandler(IUnitOfWork lessonRepository, ILearningCoreMapper<LearningTask, LearningTaskReadDTO> mapper)
        {
            this.lessonRepository = lessonRepository;
            this.mapper = mapper;
        }
        public async Task<LearningTaskReadDTO> Handle(GetSingleTaskQuery request, CancellationToken cancellationToken)
        {
            var requestedTask = await lessonRepository.LearningTaskRepository.GetSingleAsync(request.TargetId);

            var mappedTask = mapper.ConvertFrom(requestedTask);
            return mappedTask;
        }
    }
}
