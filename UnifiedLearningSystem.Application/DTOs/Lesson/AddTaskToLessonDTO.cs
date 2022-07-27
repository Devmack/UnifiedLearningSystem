namespace UnifiedLearningSystem.Application.DTOs.Lesson
{
    public record AddTaskToLessonDTO
    {
        public string LessonName { get; set; }
        public ICollection<Guid> TasksRelated { get; set; }
    }
}
