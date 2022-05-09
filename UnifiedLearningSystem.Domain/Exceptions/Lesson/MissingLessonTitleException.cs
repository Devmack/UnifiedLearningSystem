namespace UnifiedLearningSystem.Domain.Exceptions.Lesson
{
    public class MissingLessonTitleException : LearningSystemException
    {
        public MissingLessonTitleException(string msg) : base("Entity cannot be created due to empty title")
        {
        }
    }
}
