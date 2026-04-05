using Shared.Abstractions;

namespace Shared.Identity.Request;

public class SearchUserRequest : PagedRequest
{
    public string? Name { get; set; }
    public string? Document { get; set; }
    public DateTime? BirthDate { get; set; }
}
