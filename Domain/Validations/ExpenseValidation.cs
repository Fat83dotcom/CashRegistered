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
            .MaximumLength(100);
        RuleFor(expense => expense.ExpenseValue)
            .GreaterThan(0)
            .NotEmpty()
            .NotNull();
        RuleFor(expense => expense.CashFlowId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}