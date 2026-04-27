using Shared.Abstractions;

namespace Shared.Inventory.Request;

public class SearchUnitOfMeasureRequest : PagedRequest
{
    public string? Term { get; set; }
}
