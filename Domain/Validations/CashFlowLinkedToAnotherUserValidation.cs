using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class CashFlowLinkedToAnotherUserValidation : AbstractValidator<CashFlow>
{
    public CashFlowLinkedToAnotherUserValidation(int cashFlowIdFromAnotherUser)
    {
        RuleFor(c => c.Id)
            .Equal(cashFlowIdFromAnotherUser)
            .WithMessage("O usuário já possui registro em  outro fluxo de caixa.");
    }
}