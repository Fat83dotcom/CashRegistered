using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class UserIdMatchCashFlowValidation : AbstractValidator<User>
{
    public UserIdMatchCashFlowValidation(int cashFlowId)
    {
        RuleFor(user => user.CashFlow!.Id)
            .Equal(cashFlowId)
            .WithMessage("O caixa informado não pertence ao usuário.");
    }
}