namespace UnifiedLearningSystem.Application.Shared.Pagination
{
    public interface IPaginationService
    {
        public Task<int> CountPagesAsync();
    }
}
