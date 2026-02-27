using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class CashFlowLinkedToUserValidation : AbstractValidator<CashFlow>
{
    public CashFlowLinkedToUserValidation()
    {
        RuleFor(c => c.Id)
            .Equal(0)
            .WithMessage("O usuário já possui registro em outro fluxo de caixa.");
    }
}