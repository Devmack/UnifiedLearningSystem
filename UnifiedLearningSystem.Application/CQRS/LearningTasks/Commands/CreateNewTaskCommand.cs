using MediatR;
using UnifiedLearningSystem.Application.DTOs.LearningTask;
using UnifiedLearningSystem.Application.Mappers;
using UnifiedLearningSystem.Application.Shared.Repository;
using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Application.CQRS.LearningTasks.Commands
{
    public class CreateNewTaskCommand : IRequest<bool>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }


    public class CreateNewTaskCommandHandler : IRequestHandler<CreateNewTaskCommand, bool>
    {
        private readonly ILearningTaskRepository learningTaskRepository;
        private readonly ILearningCoreMapper<LearningTask, LearningTaskCreateDTO> learningCoreMapper;

        public CreateNewTaskCommandHandler(ILearningTaskRepository learningTaskRepository, ILearningCoreMapper<LearningTask, LearningTaskCreateDTO> learningCoreMapper)
        {
            this.learningTaskRepository = learningTaskRepository;
            this.learningCoreMapper = learningCoreMapper;
        }
        public async Task<bool> Handle(CreateNewTaskCommand request, CancellationToken cancellationToken)
        {
            var newTask = new LearningTaskCreateDTO(request.Title, request.Description);
            var mapped = learningCoreMapper.ConvertFrom(newTask);

            await learningTaskRepository.AddAsync(mapped);
            return true;
        }

        
    }
}
