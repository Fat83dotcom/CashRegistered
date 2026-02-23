using Domain.Validations;
using Shared.ValueObjects;

namespace Domain.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        
        Validate(this, new NameValidator());
    }
    
    
    public string FirstName { get; private set; }

    public string LastName { get; private set; }
}