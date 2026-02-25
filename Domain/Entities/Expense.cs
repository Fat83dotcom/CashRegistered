using Shared.Abstractions;

namespace Domain.Entities;

public class Expense : BaseEntity
{
    public Expense(string expenseDescription, decimal expenseValue, int cashFlowId)
    {
        ExpenseDescription = expenseDescription;
        ExpenseValue = expenseValue;
    }

    protected Expense() {}
    
    public string ExpenseDescription { get; private set; }

    public decimal ExpenseValue { get; private set; }

    public int CashFlowId { get; init; }

    public CashFlow CashFlow { get; init; }
}