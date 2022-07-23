using UnifiedLearningSystem.Domain.DomainEvents.TaskUser;
using UnifiedLearningSystem.Domain.ValueObjects.TaskUser;

namespace UnifiedLearningSystem.Domain.Entities
{
    public class TaskUser : AggregateRoot
    {
        public Guid TaskOwnerUserID { get; private set; }
        public Guid TaskID { get; private set; }
        public DateTime TimeOfSubmission { get; set; }
        public TaskRepositoriumLink RepositoriumLink { get; private set; }
        public List<TaskReview> TaskUserReviews { get; private set; }

        public TaskUser()
        {

        }

        internal TaskUser(Guid taskOwnerUserID, Guid taskID, TaskRepositoriumLink repositoriumLink, List<TaskReview> taskUserReviews, DateTime time)
        {
            TaskOwnerUserID = taskOwnerUserID;
            TaskID = taskID;
            RepositoriumLink = repositoriumLink;
            TaskUserReviews = taskUserReviews;
            TimeOfSubmission = time;

            AddEvent(new TaskUserCreated(TaskID.ToString()));
        }

        public void ReviewTask(TaskReview review)
        {
            TaskUserReviews.Add(review);
            AddEvent(new TaskReviewAdded());
        } 


    }
}
