using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Domain.Factories
{
    public static class LearningLessonFactory
    {
        public static LearningLesson Build(string title, ICollection<LearningTask> tasks)
        {
            return new LearningLesson(title, tasks);
        }
    }
}
