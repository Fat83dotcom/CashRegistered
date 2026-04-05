namespace Shared.Identity.Request;

public class CreatePersonRequest
{
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public DateTime BirthDate { get; set; }
    
    public string Document { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string CellPhone { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Gender{ get; set; } = null!;
}