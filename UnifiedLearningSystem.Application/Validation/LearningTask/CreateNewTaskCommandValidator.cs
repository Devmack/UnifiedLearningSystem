using FluentValidation;
using UnifiedLearningSystem.Application.CQRS.LearningTasks.Commands;

namespace UnifiedLearningSystem.Application.Validation.LearningTask
{
    public class CreateNewTaskCommandValidator : AbstractValidator<CreateNewTaskCommand>
    {
        public CreateNewTaskCommandValidator()
        {
            RuleFor(task => task.Title)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(task => task.Description)
                .MaximumLength(1000)
                .NotEmpty();
        }
    }
}
