using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class UserValidation : AbstractValidator<User>
{
    public UserValidation()
    {
        
        RuleFor(user => user.UserName)
            .NotNull()
            .WithMessage("O nome de usuário é obrigatório.")
            .NotEmpty()
            .WithMessage("O nome de usuário é obrigatório.")
            .MaximumLength(50)
            .WithMessage("O nome de usuário deve conter no máximo 50 caracteres.");
        RuleFor(user => user.RawPassword)
            .NotNull()
            .WithMessage("A senha é obrigatória.")
            .NotEmpty()
            .WithMessage("A senha é obrigatória.")
            .MinimumLength(12)
            .WithMessage("A senha deve conter no mínimo 12 caracteres.");
        
        RuleFor(user => user.PersonId)
            .GreaterThan(0)
            .WithMessage("O ID da pessoa é obrigatório e deve ser maior que zero.");
    }
}