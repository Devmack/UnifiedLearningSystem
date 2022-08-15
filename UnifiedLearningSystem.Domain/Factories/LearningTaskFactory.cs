using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Domain.Factories
{
    public static class LearningTaskFactory
    {
        public static LearningTask Build(string title, string description, string codeStarter, string imageHeader)
        {
            return new LearningTask(title, description, codeStarter, imageHeader);
        }
    }
}
