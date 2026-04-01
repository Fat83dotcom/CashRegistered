namespace Shared.Request;

public class CreateUserRequest
{
    

    public string Password { get; set; } = null!;

    public string UserName { get; set; } = null!;
}