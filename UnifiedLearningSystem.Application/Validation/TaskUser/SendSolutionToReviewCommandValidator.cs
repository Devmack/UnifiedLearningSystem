using FluentValidation;
using UnifiedLearningSystem.Application.CQRS.TaskUser.Commands;

namespace UnifiedLearningSystem.Application.Validation.TaskUser
{
    public class SendSolutionToReviewCommandValidator : AbstractValidator<SendSolutionToReviewCommand>
    {
        public SendSolutionToReviewCommandValidator()
        {
            RuleFor(el => el.NewTaskUserDTO).NotEmpty();
            RuleFor(el => el.NewTaskUserDTO.TaskOwnerUserID).NotEmpty();
            RuleFor(el => el.NewTaskUserDTO.RepositoriumLink.Value).Matches("(([\\w]+:)?//)?(([\\d\\w]|%[a-fA-f\\d]{2,2})+(:([\\d\\w]|%[a-fA-f\\d]{2,2})+)?@)" +
                                                        "?([\\d\\w][-\\d\\w]{0,253}[\\d\\w]\\.)+[\\w]{2,63}(:[\\d]+)?(/([-+_~.\\d\\w]|%[a-fA-f\\d]{2,2})*)" +
                                                        "*(\\?(&?([-+_~.\\d\\w]|%[a-fA-f\\d]{2,2})=?)*)?(#([-+_~.\\d\\w]|%[a-fA-f\\d]{2,2})*)?");
            RuleFor(el => el.NewTaskUserDTO.TaskID).NotEmpty();


        }
    }
}
