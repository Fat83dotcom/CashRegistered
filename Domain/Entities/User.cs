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
    public User(Name name, DateTime birthdate, string document)
    {
        Name = name;
        Birthdate = birthdate;
        Document = document;
        
        Validate(this, new UserValidation()!, errors => new DomainException(errors));
    }
    protected User() {}

    public Name Name { get; private set; }

    public DateTime Birthdate { get; private set; }

    public string Document { get; private set; }
    
    public CashFlow? CashFlow { get; private set; }

    public static void UserExists(User? targetUser)
    {
        Validate(
            targetUser,
            new NullableValidation<User>(),
            errors => new DomainException(errors),
        new List<string> {"O usuário não existe."}
        );
    }

    public void UserIdMatchCashFlow(int cashFlowId)
    {
        Validate(
            this,
            new UserIdMatchCashFlowValidation(cashFlowId),
            errors => new DomainException(errors),
            new List<string> {"O usuário não possui um cash flow cadastrado."}
        );
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