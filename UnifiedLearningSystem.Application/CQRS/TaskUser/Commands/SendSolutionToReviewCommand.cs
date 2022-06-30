using MediatR;
using UnifiedLearningSystem.Application.DTOs.TaskUser;
using UnifiedLearningSystem.Application.Mappers;
using UnifiedLearningSystem.Application.Shared.Repository;

namespace UnifiedLearningSystem.Application.CQRS.TaskUser.Commands
{
    public class SendSolutionToReviewCommand : IRequest<bool>
    {
        public TaskUserCreateDTO NewTaskUserDTO { get; set; }

        public SendSolutionToReviewCommand(TaskUserCreateDTO newTaskUserDTO)
        {
            NewTaskUserDTO = newTaskUserDTO;
        }
    }

    public class SendSolutionToReviewCommandHandler : IRequestHandler<SendSolutionToReviewCommand, bool>
    {
        private readonly IUnitOfWork repository;
        private readonly ILearningCoreMapper<TaskUserCreateDTO, Domain.Entities.TaskUser> mapper;

        public SendSolutionToReviewCommandHandler(IUnitOfWork repository, ILearningCoreMapper<TaskUserCreateDTO, Domain.Entities.TaskUser> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(SendSolutionToReviewCommand request, CancellationToken cancellationToken)
        {
            var mappedTaskUser = mapper.ConvertFrom(request.NewTaskUserDTO);
            await repository.TaskUserRepository.AddAsync(mappedTaskUser);

            return true;
        }
    }
}
