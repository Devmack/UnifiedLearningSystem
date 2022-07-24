using UnifiedLearningSystem.Application.Shared.Pagination;
using UnifiedLearningSystem.Application.Shared.Repository;

namespace UnifiedLearningSystem.Infrastructure.Pagination
{
    public class PaginationService : IPaginationService
    {
        private readonly ILearningTaskRepository repository;

        public PaginationService(ILearningTaskRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> CountPagesAsync()
        {
            return await repository.CountElements();
        }
    }
}
