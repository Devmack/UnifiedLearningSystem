using MediatR;
using UnifiedLearningSystem.Application.DTOs.TaskUser;
using UnifiedLearningSystem.Application.Mappers;
using UnifiedLearningSystem.Application.Shared.Repository;
using UnifiedLearningSystem.Domain.ValueObjects.TaskUser;

namespace UnifiedLearningSystem.Application.CQRS.TaskUser.Commands
{
    public class ReviewSolutionCommand : IRequest<bool>
    {
        public Guid TargetId { get; }
        public string ReviewContent { get; }

        public ReviewSolutionCommand(Guid targetId, string reviewContent)
        {
            TargetId = targetId;
            ReviewContent = reviewContent;
        }       
    }

    public class ReviewSolutionCommandHandler : IRequestHandler<ReviewSolutionCommand, bool>
    {
        private readonly IUnitOfWork repository;
        private readonly ILearningCoreMapper<TaskUserReadDTO, Domain.Entities.TaskUser> mapper;

        public ReviewSolutionCommandHandler(IUnitOfWork repository, ILearningCoreMapper<TaskUserReadDTO, Domain.Entities.TaskUser> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(ReviewSolutionCommand request, CancellationToken cancellationToken)
        {
            var searchedTaskToReview = await repository.TaskUserRepository.GetSingleAsync(request.TargetId);
            searchedTaskToReview.ReviewTask(new TaskReview() { Value = request.ReviewContent });
            await repository.TaskUserRepository.UpdateAsync(searchedTaskToReview);

            return true;
        }
    }
}
