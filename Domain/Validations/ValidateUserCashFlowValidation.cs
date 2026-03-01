using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class ValidateUserCashFlowValidation : AbstractValidator<User>
{
    public ValidateUserCashFlowValidation(int foreignCashFlowId)
    {
        RuleFor(user => user.CashFlow!.Id)
            .Equal(foreignCashFlowId)
            .WithMessage("O fluxo de caixa informado não pertence ao usuário.");
    }
}