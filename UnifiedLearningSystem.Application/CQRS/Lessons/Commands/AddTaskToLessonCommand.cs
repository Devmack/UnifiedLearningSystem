using MediatR;
using UnifiedLearningSystem.Application.DTOs.Lesson;
using UnifiedLearningSystem.Application.Mappers;
using UnifiedLearningSystem.Application.Shared.Repository;
using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Application.CQRS.Lessons.Commands
{
    public class AddTaskToLessonCommand : IRequest<bool>
    {
        public AddTaskToLessonDTO value{ get; set; }

        public AddTaskToLessonCommand(AddTaskToLessonDTO request)
        {
            value = request;
        }
    }

    public class AddTaskToLessonCommandHandler : IRequestHandler<AddTaskToLessonCommand, bool>
    {
        private readonly IUnitOfWork repository;
        private readonly ILearningCoreMapper<AddTaskToLessonDTO, LearningLesson> learningCoreMapper;

        public AddTaskToLessonCommandHandler(IUnitOfWork repository, ILearningCoreMapper<AddTaskToLessonDTO, LearningLesson> learningCoreMapper)
        {
            this.repository = repository;
            this.learningCoreMapper = learningCoreMapper;
        }
        public async Task<bool> Handle(AddTaskToLessonCommand request, CancellationToken cancellationToken)
        {

            var mapped = learningCoreMapper.ConvertFrom(request.value);
            await repository.LearningLessonRepository.UpdateAsync(mapped);

            return true;
        }


    }

}
