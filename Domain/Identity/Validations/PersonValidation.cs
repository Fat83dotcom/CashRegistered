using Domain.Identity.Entities;
using Domain.Financial.Entities;
using FluentValidation;

namespace Domain.Identity.Validations;

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
        RuleFor(person => person.TaxId)
            .NotNull()
            .WithMessage("O CPF/CNPJ é obrigatório.")
            .NotEmpty()
            .WithMessage("O CPF/CNPJ é obrigatório.")
            .MaximumLength(14)
            .WithMessage("O CPF/CNPJ deve conter no máximo 14 caracteres.");
        RuleFor(person => person.Email)
            .NotNull()
            .WithMessage("O email é obrigatório.")
            .NotEmpty()
            .WithMessage("O email é obrigatório.")
            .MaximumLength(100)
            .WithMessage("O email deve conter no máximo 100 caracteres.");
    }
}
