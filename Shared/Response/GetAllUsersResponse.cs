using Shared.ValueObjects;

namespace Shared.Response;

public class GetAllUsersResponse
{
    public Name Name { get; set; }

    public DateTime Birthdate { get; set; }

    public string Document { get; set; }
}