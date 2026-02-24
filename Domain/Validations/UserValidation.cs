using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class UserValidation : AbstractValidator<User>
{
    public UserValidation()
    {
        RuleFor(user => user.Birthdate).NotNull().NotEmpty();
        RuleFor(user => user.Document).NotNull().NotEmpty().MaximumLength(11);
    }
}