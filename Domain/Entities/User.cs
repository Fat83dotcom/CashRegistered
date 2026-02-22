namespace Domain.Entities;

public class User
{
    public User(string firstName, string lastName, DateTime birthdate, string document)
    {
        FirstName = firstName;
        LastName = lastName;
        Birthdate = birthdate;
        Document = document;
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public DateTime Birthdate { get; private set; }

    public string Document { get; private set; }
}