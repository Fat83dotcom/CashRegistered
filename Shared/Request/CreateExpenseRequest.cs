namespace Shared.Request;

public class CreateExpenseRequest
{
    public int UserId { get; set; }

    public int CashFlowId { get; set; }
    
    public decimal ExpenseValue { get; set; }

    public required string ExpenseDescription { get; set; }
}