namespace UnifiedLearningSystem.Application.Shared.Statistics
{
    public interface IStatsService
    {
        Task<int> GetSubmissionCountAsync(Guid searchedTask);
    }
}
