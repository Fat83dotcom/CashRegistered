namespace Shared.Identity.Request;

public class CreateUserRequest
{
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public DateTime? BirthDate { get; set; }
    
    public string? Document { get; set; }

    public string? Email { get; set; }

    public string? CellPhone { get; set; }

    public string? Phone { get; set; }

    public string? Gender{ get; set; }

    public string Role { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public int? PersonId { get; set; }
}