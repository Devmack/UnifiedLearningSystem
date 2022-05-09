using UnifiedLearningSystem.Domain.DomainEvents;

namespace UnifiedLearningSystem.Domain.Entities
{
    public class LearningTask : AggregateRoot
    {
        private TaskTitle _taskTitle;
        private TaskDescription _taskDescription;

        public LearningTask(TaskTitle taskTitle, TaskDescription taskDescription)
        {
            _taskTitle = taskTitle;
            _taskDescription = taskDescription;

            AddEvent(new LearningTaskCreatedEvent(this));
        }

        public void ChangeTitle(TaskTitle newTitle)
        {
            _taskTitle = newTitle;

            AddEvent(new LearningTaskTitleChangedEvent(newTitle));
        }

        public void ChangeDescription(TaskDescription taskDescription)
        {
            _taskDescription = taskDescription;

            AddEvent(new LearningTaskDescriptionChangedEvent(taskDescription));
        }

        public override string ToString()
        {
            return $"Task: {_taskTitle}";
        }


    }
}
