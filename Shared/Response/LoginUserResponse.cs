using Shared.ValueObjects;

namespace Shared.Response;

public class LoginUserResponse
{
    public string AccessToken { get; set; } = string.Empty;

    public int Id { get; set; }

    public Name? UserName { get; set; }

    public string Role { get; set; } = string.Empty;

}