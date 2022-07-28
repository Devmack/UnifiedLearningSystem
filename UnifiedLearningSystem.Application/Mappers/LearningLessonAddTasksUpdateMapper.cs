using UnifiedLearningSystem.Application.DTOs.LearningTask;
using UnifiedLearningSystem.Application.DTOs.Lesson;
using UnifiedLearningSystem.Application.Shared.Repository;
using UnifiedLearningSystem.Domain.Entities;
using UnifiedLearningSystem.Domain.Factories;

namespace UnifiedLearningSystem.Application.Mappers
{
    public class LearningLessonAddTasksUpdateMapper : ILearningCoreMapper<AddTaskToLessonDTO, LearningLesson>
    {
        private readonly IUnitOfWork repository;

        public LearningLessonAddTasksUpdateMapper(IUnitOfWork repository)
        {
            this.repository = repository;
        }
        public AddTaskToLessonDTO ConvertFrom(LearningLesson createDTO)
        {
            throw new NotImplementedException();
        }

        public LearningLesson ConvertFrom(AddTaskToLessonDTO updateDto)
        {
            var taskCollection = updateDto.TasksRelated.ToList();
            List<LearningTask> targetList = new ();

            taskCollection.ForEach(el => targetList.Add(repository.LearningTaskRepository.GetSingle(el)));
            LearningLesson searchedLesson = repository.LearningLessonRepository.GetSubsetBasedOn(el => el.Title == updateDto.LessonName).First();

            searchedLesson.AddTasks(targetList);

            return searchedLesson;
        }
    }
}
