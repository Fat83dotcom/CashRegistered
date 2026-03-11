using Domain.Validations;
using Shared.Abstractions;
using Shared.Exceptions;
using Shared.ValueObjects;

namespace Domain.Entities;

public class InClassName(User? user)
{
    public User? User { get; } = user;
}

public class User : BaseEntity
{
    public User(
        Name name,
        DateTime birthdate,
        string document,
        string email,
        string password,
        string userName
    )
    {
        Name = name;
        Birthdate = birthdate;
        Document = document;
        Email = email;
        Password = password;
        UserName = userName;
        
        Validate(this, new UserValidation()!, errors => new DomainException(errors));
    }
    protected User() {}

    public Name Name { get; private set; }

    public DateTime Birthdate { get; private set; }

    public string Document { get; private set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string UserName { get; set; }
    
    public CashFlow? CashFlow { get; private set; }

    public static void ValidateUserExists(User? targetUser)
    {
        Validate(
            targetUser,
            new NullableValidation<User>(),
            errors => new DomainException(errors),
        new List<string> {"O usuário não existe."}
        );
    }

    public void ValidateUserIdMatchCashFlow(int cashFlowId)
    {
        Validate(
            this,
            new UserIdMatchCashFlowValidation(cashFlowId)!,
            errors => new DomainException(errors)
        );
    }

    public void ValidateUserHasCashFlow()
    {
        if (CashFlow == null)
        {
            Validate(
            CashFlow,
            new NullableValidation<CashFlow>(),
            error => new DomainException(error),
            new List<string> {"O usuário não possui um cash flow cadastrado."}
            );
        }
    }

    public void ValidateUserCashFlow(int cashFlowId)
    {
        Validate(
            this,
            new ValidateUserCashFlowValidation(cashFlowId)!,
            errors => new DomainException(errors)
        );
    }
}