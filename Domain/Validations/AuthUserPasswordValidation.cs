using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class AuthUserPasswordValidation : AbstractValidator<ValidationResultWrapper>
{
    public AuthUserPasswordValidation()
    {
        RuleFor(x => x.IsValid)
            .Equal(true)
            .WithMessage("Senha incorreta.");
    }
}