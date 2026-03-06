using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class ValidateUserIdValidation : AbstractValidator<CashFlow>
{
    public ValidateUserIdValidation()
    {
        RuleFor(cashFlow => cashFlow.UserId).NotNull().NotEmpty().GreaterThan(0);
    }
}