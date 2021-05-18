using FluentValidation;

namespace Statistics.Core.Endoints.Team
{
    public class DeleteCommandValidator : AbstractValidator<DeleteCommand>
    {
        public DeleteCommandValidator()
        {
            RuleFor(_ => _.Id).GreaterThan(0).WithMessage("Id should be set");
        }
    }
}