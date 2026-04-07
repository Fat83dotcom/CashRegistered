using Shared.Abstractions;

namespace Shared.Identity.Request;

public class SearchUserRequest : PagedRequest
{
    public string? Name { get; set; }
    public string? TaxId { get; set; }
    public DateTime? BirthDate { get; set; }
}
