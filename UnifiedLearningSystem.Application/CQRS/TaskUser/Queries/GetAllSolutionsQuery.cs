using MediatR;
using UnifiedLearningSystem.Application.DTOs.TaskUser;
using UnifiedLearningSystem.Application.Mappers;
using UnifiedLearningSystem.Application.Shared.QueryHelper;
using UnifiedLearningSystem.Application.Shared.Repository;

namespace UnifiedLearningSystem.Application.CQRS.TaskUser.Queries
{
    public class GetAllSolutionsQuery : IRequest<List<TaskUserReadDTO>>
    {
        public PageQuery PageQuery { get; set; }

        public GetAllSolutionsQuery(PageQuery pageQuery)
        {
            PageQuery = pageQuery;
        }
    }

    public class GetAllSolutionsQueryHandler : IRequestHandler<GetAllSolutionsQuery, List<TaskUserReadDTO>>
    {
        private readonly IUnitOfWork repository;
        private readonly ILearningCoreMapper<TaskUserReadDTO, Domain.Entities.TaskUser> mapper;

        public GetAllSolutionsQueryHandler(IUnitOfWork repository, ILearningCoreMapper<TaskUserReadDTO, Domain.Entities.TaskUser> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<TaskUserReadDTO>> Handle(GetAllSolutionsQuery request, CancellationToken cancellationToken)
        {
            var targetSolutions = await repository.TaskUserRepository.GetAllAsync(request.PageQuery);
            var targetMappedSolutions = new List<TaskUserReadDTO>();
            targetSolutions.ToList().ForEach(el => targetMappedSolutions.Add(mapper.ConvertFrom(el)));

            return targetMappedSolutions;
        }
    }
}
