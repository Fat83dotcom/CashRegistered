namespace Domain.Entities;

public class CashFlow
{
    public CashFlow(int userId)
    {
        UserId = userId;
    }

    public decimal CurrentBalance { get; private set; }

    public string ExpenseDescription { get; private set; }

    public decimal ExpenseValue { get; private set; }
    
    public int UserId { get; private set; }
}