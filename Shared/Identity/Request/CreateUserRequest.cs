namespace Shared.Identity.Request;

public class CreateUserRequest
{
    public string Role { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public int? PersonId { get; set; }
}