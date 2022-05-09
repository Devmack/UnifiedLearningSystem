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

            AddEvent(new LearningTaskCreated());
        }

        public void ChangeTitle(TaskTitle newTitle)
        {
            _taskTitle = newTitle;

            AddEvent(new LearningTaskTitleChanged());
        }

        public void ChangeDescription(TaskDescription taskDescription)
        {
            _taskDescription = taskDescription;

            AddEvent(new LearningTaskDescriptionChanged());
        }

        
    }
}
