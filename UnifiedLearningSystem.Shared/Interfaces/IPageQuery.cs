namespace UnifiedLearningSystem.CommonAbstraction.Interfaces
{
    public interface IPageQuery
    {
        public int ElementsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int MaxElements { get; set; }
    }
}
