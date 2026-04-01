using Domain.Enums;
using Domain.ValueObjects;
using Shared.Abstractions;
using Shared.ValueObjects;

namespace Domain.Entities;

public class Person : BaseEntity
{
    public Person(
        Name name,
        string document,
        DateTime birthdate,
        string email,
        string cellPhone,
        string phone,
        Gender gender
    )
    {
        Name = name;
        Document = document;
        Birthdate = birthdate;
        Email = email;
        CellPhone = cellPhone;
        Phone = phone;
        Gender = gender;
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
}