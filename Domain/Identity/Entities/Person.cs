using Domain.Identity.Enums;
using Domain.Identity.ValueObjects;
using Shared.Abstractions;
using Shared.Notifications;
using Shared.ValueObjects;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Identity.Entities;

public class Person : BaseEntity
{
    private readonly List<Notification> _notifications = new();
    public IReadOnlyCollection<Notification> Notifications => _notifications.AsReadOnly();
    public bool IsInvalid => _notifications.Any();

    public Person(
        PersonType personType,
        string firstName,
        string lastName,
        string taxId,
        DateTime birthdate,
        string email,
        string? tradeName = null,
        string? stateRegistration = null,
        string? municipalRegistration = null,
        string? cellPhone = null,
        string? phone = null,
        string? gender = null
    )
    {
        PersonType = personType;
        Name = new Name(firstName, lastName);
        TaxId = taxId;
        Birthdate = birthdate;
        Email = email;
        TradeName = tradeName;
        StateRegistration = stateRegistration;
        MunicipalRegistration = municipalRegistration;
        CellPhone = cellPhone ?? string.Empty;
        Phone = phone ?? string.Empty;
        Gender = Enum.TryParse(gender, out Gender result) ? result : Enums.Gender.Other;

        // Validação inicial (Design by Contract)
        Validate();
    }

    protected Person() { }

    public PersonType PersonType { get; set; }
    public Name Name { get; set; }
    public string TaxId { get; set; } // CPF or CNPJ
    public string? TradeName { get; set; } // Nome Fantasia
    public string? StateRegistration { get; set; } // IE
    public string? MunicipalRegistration { get; set; } // IM
    public DateTime Birthdate { get; set; }
    public string Email { get; set; }
    public string CellPhone { get; set; }
    public string Phone { get; set; }
    public Gender Gender { get; set; }

    private readonly List<Address> _addresses = new();
    public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();

    private void Validate()
    {
        var contract = new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(TaxId, "TaxId", "O CPF/CNPJ é obrigatório.")
            .IsEmail(Email, "Email", "E-mail inválido.");
        
        if (PersonType == PersonType.Legal)
        {
            contract.IsNotNullOrEmpty(TradeName, "TradeName", "O Nome Fantasia é obrigatório para Pessoa Jurídica.");
        }

        _notifications.AddRange(contract.Notifications);
    }

    public void AddAddress(Address address)
    {
        _addresses.Add(address);
        RegisterUpdate();
    }

    public void ValidateUniquePerson(bool taxIdExists)
    {
        if (taxIdExists)
            _notifications.Add(new Notification("TaxId", "Já existe uma pessoa cadastrada com este CPF/CNPJ."));
    }

    public static void ValidatePersonExists(Person? targetPerson, NotificationContext notificationContext)
    {
        if (targetPerson == null)
            notificationContext.AddNotification("Person", "A pessoa não existe.");
    }
}
