using MediatR;
using UnifiedLearningSystem.Application.DTOs.TaskUser;
using UnifiedLearningSystem.Application.Mappers;
using UnifiedLearningSystem.Application.Shared.Repository;

namespace UnifiedLearningSystem.Application.CQRS.TaskUser.Queries
{
    public class GetAllSolutionsOfUserQuery : IRequest<List<TaskUserReadDTO>>
    {
        public Guid SearchedSolutionUserId { get; }
        public GetAllSolutionsOfUserQuery(Guid searchedSolutionUserId)
        {
            SearchedSolutionUserId = searchedSolutionUserId;
        }
    }

    public class GetAllSolutionsOfUserQueryHandler : IRequestHandler<GetAllSolutionsOfUserQuery, List<TaskUserReadDTO>>
    {
        private readonly IUnitOfWork repository;
        private readonly ILearningCoreMapper<TaskUserReadDTO, Domain.Entities.TaskUser> mapper;

        public GetAllSolutionsOfUserQueryHandler(IUnitOfWork repository, ILearningCoreMapper<TaskUserReadDTO, Domain.Entities.TaskUser> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<List<TaskUserReadDTO>> Handle(GetAllSolutionsOfUserQuery request, CancellationToken cancellationToken)
        {
            var targetSolutions = await repository.TaskUserRepository.GetSubsetBasedOnAsync(el => el.TaskOwnerUserID == request.SearchedSolutionUserId);
            var targetMappedSolutions = new List<TaskUserReadDTO>();
            targetSolutions.ToList().ForEach(el => targetMappedSolutions.Add(mapper.ConvertFrom(el)));

            return targetMappedSolutions;
        }
    }
}
