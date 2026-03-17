using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class UserValidation : AbstractValidator<User>
{
    public UserValidation()
    {
        RuleFor(user => user.Birthdate)
            .NotNull()
            .WithMessage("A data de nascimento é obrigatória.")
            .NotEmpty()
            .WithMessage("A data de nascimento é obrigatória.");
        RuleFor(user => user.Document)
            .NotNull()
            .WithMessage("O documento é obrigatório.")
            .NotEmpty()
            .WithMessage("O documento é obrigatório.")
            .Length(11)
            .WithMessage("O documento deve conter 11 caracteres.");
        RuleFor(user => user.Email)
            .NotNull()
            .WithMessage("O email é obrigatório.")
            .NotEmpty()
            .WithMessage("O email é obrigatório.")
            .MaximumLength(50)
            .WithMessage("O email deve conter no máximo 50 caracteres.");
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
    }
}