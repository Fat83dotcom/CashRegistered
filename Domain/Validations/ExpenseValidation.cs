using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class ExpenseValidation : AbstractValidator<Expense>
{
    public ExpenseValidation()
    {
        RuleFor(expense => expense.ExpenseDescription)
            .NotEmpty()
            .NotNull()
            .MaximumLength(100)
            .WithMessage("A descrição da despesa é obrigatória.");
        RuleFor(expense => expense.ExpenseValue)
            .GreaterThan(0)
            .NotEmpty()
            .NotNull()
            .WithMessage("O valor da despesa deve ser maior que zero.");
        RuleFor(expense => expense.CashFlowId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .WithMessage("O fluxo de caixa não foi informado.");
    }
}