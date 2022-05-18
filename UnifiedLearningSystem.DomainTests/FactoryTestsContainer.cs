using NUnit.Framework;
using UnifiedLearningSystem.Domain.Exceptions;
using UnifiedLearningSystem.Domain.Factories;

namespace UnifiedLearningSystem.DomainTests
{
    public class FactoryTestsContainer
    {   
        [Test]
        public void LearningTestFactoryThrowsExceptionOnEmptyTitle()
        {
            Assert.Throws<MissingTaskTitleException>(() => LearningTaskFactory.Build("", "Test Description"));
        }
    }
}