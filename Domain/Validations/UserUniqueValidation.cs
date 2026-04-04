using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class UserUniqueValidation : AbstractValidator<User>
{
    public UserUniqueValidation(bool userNameExists, bool personAlreadyHasUser)
    {
        RuleFor(x => x.UserName)
            .Must(_ => !userNameExists)
            .WithMessage("Este nome de usuário já está sendo utilizado.");

        RuleFor(x => x.PersonId)
            .Must(_ => !personAlreadyHasUser)
            .WithMessage("Esta pessoa já possui um usuário vinculado.");
    }
}
