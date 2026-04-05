namespace Shared.Financial.Request;

public class AddCashRequest
{
    public int CashFlowId { get; set; }

    public decimal Value { get; set; }
}