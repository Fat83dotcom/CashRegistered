using Shared.Abstractions;

namespace Shared.Inventory.Request;

public class SearchCategoryRequest : PagedRequest
{
    public string? Term { get; set; }
}