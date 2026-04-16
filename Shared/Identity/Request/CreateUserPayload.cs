namespace Shared.Identity.Request;

public class CreateUserPayload
{
    public required CreateUserRequest UserRequest { get; set; }
    public CreatePersonRequest? PersonRequest { get; set; }
}
