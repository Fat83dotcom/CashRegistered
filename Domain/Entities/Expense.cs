using Domain.Validations;
using Shared.Abstractions;
using Shared.Exceptions;

namespace Domain.Entities;

public class Expense : BaseEntity
{
    public Expense(string expenseDescription, decimal expenseValue, int cashFlowId)
    {
        ExpenseDescription = expenseDescription;
        ExpenseValue = expenseValue;
        CashFlowId = cashFlowId;
        
        Validate(
            this,
            new ExpenseValidation()!,
            error => new DomainException()
        );
    }

    protected Expense() {}
    
    public string ExpenseDescription { get; private set; }

    public decimal ExpenseValue { get; private set; }

    public int CashFlowId { get; init; }

    public CashFlow CashFlow { get; init; }
}