using FluentValidation;

namespace Application.Validation
{
    public class IdValidator : AbstractValidator<int>
    {
        public IdValidator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("Id is required");
        }
    }
}
