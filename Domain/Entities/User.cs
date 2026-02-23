

using Domain.ValueObjects;
using Shared.Abstractions;

namespace Domain.Entities;

public class User : BaseEntity
{
    public User(Name name, DateTime birthdate, string document)
    {
        Name = name;
        Birthdate = birthdate;
        Document = document;
    }
    protected User() { }

    // public string FirstName { get; private set; }
    //
    // public string LastName { get; private set; }

    public Name Name { get; private set; }

    public DateTime Birthdate { get; private set; }

    public string Document { get; private set; }
}