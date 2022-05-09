﻿using UnifiedLearningSystem.Domain.DomainEvents.Lesson;
using UnifiedLearningSystem.Domain.ValueObjects.Lesson;

namespace UnifiedLearningSystem.Domain.Entities
{
    public class LearningLesson : AggregateRoot
    {
        public LessonTitle Title { get; private set; }
        public ICollection<LearningTask> Tasks { get; private set; }

        public LearningLesson(LessonTitle title, ICollection<LearningTask> tasks)
        {
            Title = title;
            Tasks = tasks;

            AddEvent(new LessonCreatedEvent(this));
        }

        public void ChangeTitle(LessonTitle newTitle)
        {
            Title = newTitle;

            AddEvent(new LessonTitleChanged(newTitle));
        }

        public void AddTask(LearningTask task)
        {
            Tasks.Add(task);

            AddEvent(new NewTaskAddedEvent(task));
        }

        public override string ToString()
        {
            return $"Lesson: {Title}";
        }
    }
}
