using Shared.ValueObjects;

namespace Shared.Financial.Response;

public class GetExpensesByCashFlowIdResponse
{
    public int CashFlowId { get; set; }

    public int UserId { get; set; }

    public required Name UserName { get; set; }

    public IEnumerable<ExpenseValues>? ExpenseValues { get; set; }
}

public class ExpenseValues
{
    public required string ExpenseDescription { get; set; }

    public decimal Value { get; set; }
}