using Domain.Validations;
using Shared.Abstractions;
using Shared.Exceptions;
using Shared.ValueObjects;

namespace Domain.Entities;

public class User : BaseEntity
{
    public User(Name name, DateTime birthdate, string document)
    {
        Name = name;
        Birthdate = birthdate;
        Document = document;
        
        Validate(this, new UserValidation(), errors => new DomainException(errors));
    }
    protected User() {}

    public Name Name { get; private set; }

    public DateTime Birthdate { get; private set; }

    public string Document { get; private set; }
    
    public CashFlow? CashFlow { get; private set; }
}