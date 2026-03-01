using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class ValidateUserIdValidation : AbstractValidator<User>
{
    public ValidateUserIdValidation()
    {
        RuleFor(user => user.Id).NotNull().NotEmpty().GreaterThan(0);
    }
}