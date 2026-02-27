using Domain.Validations;
using Shared.Abstractions;
using Shared.Exceptions;

namespace Domain.Entities;

public class CashFlow : BaseEntity
{
    public CashFlow(int userId)
    {
        ValidateUserId(userId);
    }

    protected CashFlow() {}

    public decimal? CurrentBalance { get; private set; } = 0;
    
    public int UserId { get; private set; }
    
    public User? User { get; init; }

    public IReadOnlyCollection<Expense>? Expenses { get; init; }

    private void ValidateUserId(int userId)
    {
        Validate(
            userId,
            new ValidateUserIdValidation(), error => new DomainException(error)
        );
        UserId = userId;
    }

    public void UpdateCurrentBalance(decimal? newValue)
    {
        if (newValue is 0 or null) return;
        CurrentBalance = newValue;
        RegisterUpdate();
    }

    public void CashFlowLinkedToUser(User? user)
    {
        if (user?.CashFlow == null) return;

        Id = user.CashFlow.Id;
            
        Validate(
            this,
            new CashFlowLinkedToUserValidation(),
            error => new DomainException(error)
        );
        
    }
}