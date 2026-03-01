using Shared.ValueObjects;

namespace Shared.Response;

public class GetExpensesByCashFlowIdResponse
{
    public int CashFlowId { get; set; }

    public int UserId { get; set; }

    public Name UserName { get; set; }

    public IEnumerable<ExpenseValues>? ExpenseValues { get; set; }
}

public class ExpenseValues
{
    public string ExpenseDescription { get; set; }

    public decimal Value { get; set; }
}