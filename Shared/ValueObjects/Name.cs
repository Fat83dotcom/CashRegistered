using Domain.Validations;
using Shared.Exceptions;

namespace Shared.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        
        Validate(this, new NameValidator(), errors => new DomainException(errors));
    }
    
    protected Name() { }
    
    public string FirstName { get; private set; }

    public string LastName { get; private set; }
}