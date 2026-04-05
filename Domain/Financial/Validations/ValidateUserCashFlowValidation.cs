using Domain.Identity.Entities;
using Domain.Financial.Entities;
using FluentValidation;

namespace Domain.Financial.Validations;

public class ValidateUserCashFlowValidation : AbstractValidator<User>
{
    public ValidateUserCashFlowValidation(int foreignCashFlowId)
    {
        RuleFor(user => user.CashFlow!.Id)
            .Equal(foreignCashFlowId)
            .WithMessage("O fluxo de caixa informado não pertence ao usuário.");
    }
}