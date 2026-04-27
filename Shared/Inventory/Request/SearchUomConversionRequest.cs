using Shared.Abstractions;

namespace Shared.Inventory.Request;

public class SearchUomConversionRequest : PagedRequest
{
    public string? Term { get; set; }
}