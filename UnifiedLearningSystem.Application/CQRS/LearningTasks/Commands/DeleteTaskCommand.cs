using MediatR;
using UnifiedLearningSystem.Application.Shared.Repository;

namespace UnifiedLearningSystem.Application.CQRS.LearningTasks.Commands
{
    public class DeleteTaskCommand : IRequest<bool>
    {
        public Guid TargetGuid { get; set; }

        public DeleteTaskCommand(Guid targetGuid)
        {
            TargetGuid = targetGuid;
        }
    }

    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly IUnitOfWork repository;

        public DeleteTaskCommandHandler(IUnitOfWork repository)
        {
            this.repository = repository;
        }
        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var targetTask = await repository.LearningTaskRepository.GetSingleAsync(request.TargetGuid);
            if (targetTask != null)
            {
                await repository.LearningTaskRepository.DeleteAsync(targetTask);
                return true;
            }
            return false;

        }
    }
}
