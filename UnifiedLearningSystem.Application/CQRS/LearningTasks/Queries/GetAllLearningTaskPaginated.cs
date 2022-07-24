using MediatR;
using UnifiedLearningSystem.Application.DTOs.LearningTask;
using UnifiedLearningSystem.Application.Mappers;
using UnifiedLearningSystem.Application.Shared.Pagination;
using UnifiedLearningSystem.Application.Shared.QueryHelper;
using UnifiedLearningSystem.Application.Shared.Repository;
using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Application.CQRS.LearningTasks.Queries
{
    public class GetAllLearningTaskPaginated : IRequest<List<LearningTaskReadDTO>>
    {
        public PageQuery PageQuery { get; set; }

        public GetAllLearningTaskPaginated(PageQuery pageQuery)
        {
            PageQuery = pageQuery;
        }
    }

    public class GetAllLearningTaskPaginatedyHandler : IRequestHandler<GetAllLearningTaskPaginated, List<LearningTaskReadDTO>>
    {
        private readonly IUnitOfWork repository;
        private readonly ILearningCoreMapper<LearningTask, LearningTaskReadDTO> mapper;
        private readonly IPaginationService paginationService;

        public GetAllLearningTaskPaginatedyHandler(IUnitOfWork repository, ILearningCoreMapper<LearningTask, LearningTaskReadDTO> mapper, IPaginationService paginationService)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.paginationService = paginationService;
        }

        public async Task<List<LearningTaskReadDTO>> Handle(GetAllLearningTaskPaginated request, CancellationToken cancellationToken)
        {
            request.PageQuery.MaxElements = await paginationService.CountPagesAsync();
            var targetSolutions = await repository.LearningTaskRepository.GetAllAsync(request.PageQuery);
            var targetMappedSolutions = new List<LearningTaskReadDTO>();
            targetSolutions.ToList().ForEach(el => targetMappedSolutions.Add(mapper.ConvertFrom(el)));

            return targetMappedSolutions;
        }
    }
}
