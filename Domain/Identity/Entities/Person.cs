using Domain.Identity.Enums;
using Domain.Identity.Validations;
using Domain.Financial.Validations;
using Domain.Validations;
using Domain.Identity.ValueObjects;
using Shared.Abstractions;
using Shared.Exceptions;
using Shared.ValueObjects;

namespace Domain.Identity.Entities;

public class Person : BaseEntity
{
    public Person(
        string firstName,
        string lastName,
        string document,
        DateTime birthdate,
        string email,
        string cellPhone,
        string phone,
        string gender
    )
    {
        Name = new Name(firstName, lastName);
        Document = document;
        Birthdate = birthdate;
        Email = email;
        CellPhone = cellPhone;
        Phone = phone;
        Gender = Enum.TryParse(gender, out Gender result) ? result : Gender.Other;
        
        Validate(
            this,
            new PersonValidation()!,
            errors => new DomainException(errors)
        );
    }
    protected Person(){}
    public Name Name { get; set; }

    public string Document { get; set; }

    public DateTime Birthdate { get; set; }

    public string Email { get; set; }
    
    public string CellPhone { get; set; }

    public string Phone { get; set; }

    public Gender Gender { get; set; }
    
    private readonly List<Address> _addresses = new();
    
    public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();

    public void UpdateContactInfo(string email, string phone)
    {
        Email = email;
        Phone = phone;
        RegisterUpdate();
    }
    
    public void AddAddress(Address address)
    {
        _addresses.Add(address);
        RegisterUpdate();
    }

    public static void ValidatePersonExists(Person? targetPerson)
    {
        Validate(
            targetPerson,
            new NullableValidation<Person>(),
            errors => new DomainException(errors),
            ["A pessoa não existe."]
        );
    }

    public void ValidateUniquePerson(bool documentExists)
    {
        Validate(
            this,
            new PersonUniqueValidation(documentExists)!,
            errors => new DomainException(errors)
        );
    }
}