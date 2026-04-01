using Domain.Enums;
using Domain.Interfaces;
using Domain.Validations;
using Shared.Abstractions;
using Shared.Exceptions;

namespace Domain.Entities;

public class InClassName(User? user)
{
    public User? User { get; } = user;
}

public class User : BaseEntity
{
    public User(
        string rawPassword,
        string userName
    )
    {
        RawPassword = rawPassword;
        UserName = userName;
        
        Validate(this, new UserValidation()!, errors => new DomainException(errors));
    }
    protected User() {}

    public int PersonId { get; set; }

    public string HashedPassword { get; set; }

    public string RawPassword { get; set; }

    public string UserName { get; set; }

    public UserRole UserRole { get; set; }
    
    public CashFlow? CashFlow { get; private set; }

    public Person Person { get; private set; }

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

    public void HashPassword(IPasswordHasher hasher)
    {
        var passwordHashed = hasher.HashPassword(RawPassword);
        HashedPassword = passwordHashed;
    }

    public bool AuthenticatePassword(IPasswordHasher hasher,  string password)
    {
        ValidationResultWrapper resultWrapper = new()
        {
            IsValid = hasher.VerifyHash(password, HashedPassword)
        };

        if (resultWrapper.IsValid) return true;
        Validate(
            resultWrapper,
            new AuthUserPasswordValidation()!,
            error => new DomainException(error)
        );
        return false;
    }
}

public class ValidationResultWrapper
{
    public bool IsValid { get; set; }
}