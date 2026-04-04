using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class PersonValidation : AbstractValidator<Person>
{
    public PersonValidation()
    {
        RuleFor(person => person.Name.FirstName)
            .NotNull()
            .WithMessage("O nome é obrigatório.")
            .NotEmpty()
            .WithMessage("O nome é obrigatório.");
        RuleFor(person => person.Name.LastName)
            .NotNull()
            .WithMessage("O sobrenome é obrigatório.")
            .NotEmpty()
            .WithMessage("O sobrenome é obrigatório.");
        RuleFor(person => person.Birthdate)
            .NotNull()
            .WithMessage("A data de nascimento é obrigatória.")
            .NotEmpty()
            .WithMessage("A data de nascimento é obrigatória.");
        RuleFor(person => person.Document)
            .NotNull()
            .WithMessage("O documento é obrigatório.")
            .NotEmpty()
            .WithMessage("O documento é obrigatório.")
            .Length(11)
            .WithMessage("O documento deve conter 11 caracteres.");
        RuleFor(person => person.Email)
            .NotNull()
            .WithMessage("O email é obrigatório.")
            .NotEmpty()
            .WithMessage("O email é obrigatório.")
            .MaximumLength(50)
            .WithMessage("O email deve conter no máximo 50 caracteres.");
        RuleFor(person => person.Phone)
            .NotNull()
            .WithMessage("O telefone é obrigatório.")
            .NotEmpty()
            .WithMessage("O telefone é obrigatório.")
            .Length(11)
            .WithMessage("O telefone deve conter 11 dígitos.");
    }
}