using Shared.Abstractions;

namespace Domain.Entities;

public class CashFlow : BaseEntity
{
    public CashFlow(int userId, IReadOnlyCollection<Expense>? expenses)
    {
        UserId = userId;
        Expenses = expenses;
    }

    protected CashFlow() {}

    public decimal CurrentBalance { get; private set; }
    
    public int UserId { get; private set; }
    
    public User? User { get; init; }

    public IReadOnlyCollection<Expense>? Expenses { get; }
}