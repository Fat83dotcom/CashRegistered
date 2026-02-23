namespace UseCase.Request.User;

public class CreateUserRequest
{
    public string FirtsName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Document { get; set; }
}