using Shared.ValueObjects;

namespace Shared.Response;

public class GetCashFlowsAvailableResponse
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public Name UserName { get; set; }

    public decimal? CurrentBalance { get; set; }
}