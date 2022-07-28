using UnifiedLearningSystem.Application.Shared.QueryHelper;

namespace UnifiedLearningSystem.Application.DTOs.LearningTask
{
    public record LearningTaskPaginatedResultDTO (List<LearningTaskReadDTO> SelectedTasks, PageQuery QueryRelated);

}
