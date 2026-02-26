using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class ValidateUserIdValidation : AbstractValidator<int>
{
    public ValidateUserIdValidation()
    {
        RuleFor(expression: userId => userId).NotNull().NotEmpty().GreaterThan(0);
    }
}