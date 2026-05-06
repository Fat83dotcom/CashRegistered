using Shared.Abstractions;

namespace Shared.Inventory.Request;

public class SearchTagRequest : PagedRequest
{
    public string? Term { get; set; }
}