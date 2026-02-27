using Shared.ValueObjects;

namespace Shared.Response;

public class GetAllUsersResponse
{
    public int Id { get; set; }
    
    public Name? Name { get; set; }

    public DateTime Birthdate { get; set; }

    public string? Document { get; set; } = string.Empty;
}