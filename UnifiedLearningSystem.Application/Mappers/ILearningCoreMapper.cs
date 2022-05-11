namespace UnifiedLearningSystem.Application.Mappers
{
    public interface ILearningCoreMapper<Target, Source>
    {
        Target ConvertFrom(Source createDTO);
        Source ConvertFrom(Target createDTO);
    }
}