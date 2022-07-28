using MediatR;
using UnifiedLearningSystem.Application.DTOs.Lesson;
using UnifiedLearningSystem.Application.Mappers;
using UnifiedLearningSystem.Application.Shared.Repository;
using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Application.CQRS.Lessons.Queries
{
    public class GetAllLessonsQuery : IRequest<ICollection<LearningLessonReadDTO>>
    {
    }

    public class GetAllLessonsQueryHandler : IRequestHandler<GetAllLessonsQuery, ICollection<LearningLessonReadDTO>>
    {
        private readonly IUnitOfWork repository;
        private readonly ILearningCoreMapper<LearningLessonReadDTO, LearningLesson> mapper;

        public GetAllLessonsQueryHandler(IUnitOfWork repository, ILearningCoreMapper<LearningLessonReadDTO, LearningLesson> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ICollection<LearningLessonReadDTO>> Handle(GetAllLessonsQuery request, CancellationToken cancellationToken)
        {
            var collection = await repository.LearningLessonRepository.GetAllAsync();
            var mappedCollection = new List<LearningLessonReadDTO>();

            foreach (var learningLesson in collection)
            {
                mappedCollection.Add(mapper.ConvertFrom(learningLesson));
            }

            return mappedCollection;
        }
    }
}
