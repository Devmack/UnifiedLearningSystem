using UnifiedLearningSystem.CommonAbstraction.Interfaces;

namespace UnifiedLearningSystem.Application.Shared.QueryHelper
{
    public class PageQuery : IPageQuery
    {
        public int ElementsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int MaxElements { get; set; }
    }
}
