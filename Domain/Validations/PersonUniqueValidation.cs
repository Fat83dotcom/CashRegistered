using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class PersonUniqueValidation : AbstractValidator<Person>
{
    public PersonUniqueValidation(bool documentExists)
    {
        RuleFor(x => x.Document)
            .Must(_ => !documentExists)
            .WithMessage("Já existe uma pessoa cadastrada com este documento.");
    }
}
