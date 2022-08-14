using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Domain.Factories
{
    public static class LearningTaskFactory
    {
        public static LearningTask Build(string title, string description, string codeStarter)
        {
            return new LearningTask(title, description, codeStarter);
        }
    }
}
