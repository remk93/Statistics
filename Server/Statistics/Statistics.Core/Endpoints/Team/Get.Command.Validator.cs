using FluentValidation;

namespace Statistics.Core.Endoints.Team
{
    public class GetCommandValidator : AbstractValidator<GetCommand>
    {
        public GetCommandValidator()
        {
            RuleFor(_ => _.Id).GreaterThan(0).WithMessage("Id should be set");
        }
    }
}