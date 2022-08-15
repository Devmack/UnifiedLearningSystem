using UnifiedLearningSystem.Domain.DomainEvents;
using UnifiedLearningSystem.Domain.ValueObjects.Task;

namespace UnifiedLearningSystem.Domain.Entities
{
    public class LearningTask : AggregateRoot
    {
        public TaskTitle TaskTitle { get; private set; }
        public TaskDescription TaskDescription { get; private set; }
        public TaskCodeStarter TaskCodeStarter { get; private set; }
        public TaskImageHeader TaskImageHeader { get; private set; }

        public LearningTask()
        {

        }
        internal LearningTask(TaskTitle taskTitle, TaskDescription taskDescription, TaskCodeStarter taskCodeStarter, TaskImageHeader taskImageHeader)
        {
            TaskTitle = taskTitle;
            TaskDescription = taskDescription;

            TaskCodeStarter = taskCodeStarter;
            TaskImageHeader = taskImageHeader;

            AddEvent(new LearningTaskCreatedEvent(this));
            
        }

        public void ChangeTitle(TaskTitle newTitle)
        {
            TaskTitle = newTitle;

            AddEvent(new LearningTaskTitleChangedEvent(newTitle));
        }

        public void ChangeDescription(TaskDescription taskDescription)
        {
            TaskDescription = taskDescription;

            AddEvent(new LearningTaskDescriptionChangedEvent(taskDescription));
        }

        public override string ToString()
        {
            return $"Task: {TaskTitle}";
        }


    }
}
