using UnifiedLearningSystem.Application.Shared.Repository;
using UnifiedLearningSystem.Application.Shared.Statistics;

namespace UnifiedLearningSystem.Infrastructure.Stats
{
    public class StatsService : IStatsService
    {
        private readonly IUnitOfWork repository;

        public StatsService(IUnitOfWork repository)
        {
            this.repository = repository;
        }
        public async Task<int> GetSubmissionCountAsync(Guid searchedTask)
        {
            var result = await repository.TaskUserRepository.GetSubsetBasedOnAsync(el => el.TaskID == searchedTask);
            return result.Count();
        }
    }
}
