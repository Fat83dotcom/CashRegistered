using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validations;

public class NameValidator : AbstractValidator<Name>
{
    public NameValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(20);
        RuleFor(x => x.LastName).MaximumLength(20);
    }
}