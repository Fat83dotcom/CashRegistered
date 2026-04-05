using Domain.Identity.Entities;
using Domain.Financial.Entities;
using FluentValidation;

namespace Domain.Financial.Validations;

public class CashFlowLinkedToUserValidation : AbstractValidator<CashFlow>
{
    public CashFlowLinkedToUserValidation()
    {
        RuleFor(c => c.Id)
            .Equal(0)
            .WithMessage("O usuário já possui registro em outro fluxo de caixa.");
    }
}