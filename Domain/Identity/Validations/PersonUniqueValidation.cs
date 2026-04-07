using Domain.Identity.Entities;
using Domain.Financial.Entities;
using FluentValidation;

namespace Domain.Identity.Validations;

public class PersonUniqueValidation : AbstractValidator<Person>
{
    public PersonUniqueValidation(bool taxIdExists)
    {
        RuleFor(x => x.TaxId)
            .Must(_ => !taxIdExists)
            .WithMessage("Já existe uma pessoa cadastrada com este CPF/CNPJ.");
    }
}
