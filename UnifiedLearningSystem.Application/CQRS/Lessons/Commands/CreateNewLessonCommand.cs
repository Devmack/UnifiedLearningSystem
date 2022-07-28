using MediatR;
using UnifiedLearningSystem.Application.DTOs.Lesson;
using UnifiedLearningSystem.Application.Mappers;
using UnifiedLearningSystem.Application.Shared.Repository;
using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Application.CQRS.Lessons.Commands
{
    public class CreateNewLessonCommand : IRequest<bool>
    {
        public LearningLessonCreateDTO CreateDTO { get; set; }

        public CreateNewLessonCommand(LearningLessonCreateDTO createDTO)
        {
            this.CreateDTO = createDTO;
        }
    }


    public class CreateNewLessonCommandHandler : IRequestHandler<CreateNewLessonCommand, bool>
    {
        private readonly IUnitOfWork repository;
        private readonly ILearningCoreMapper<LearningLessonCreateDTO, LearningLesson> learningCoreMapper;

        public CreateNewLessonCommandHandler(IUnitOfWork repository, ILearningCoreMapper<LearningLessonCreateDTO, LearningLesson> learningCoreMapper)
        {
            this.repository = repository;
            this.learningCoreMapper = learningCoreMapper;
        }
        public async Task<bool> Handle(CreateNewLessonCommand request, CancellationToken cancellationToken)
        {
           
            var mapped = learningCoreMapper.ConvertFrom(request.CreateDTO);
            await repository.LearningLessonRepository.AddAsync(mapped);

            return true;
        }


    }
}
