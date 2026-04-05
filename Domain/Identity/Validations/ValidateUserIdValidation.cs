using Domain.Identity.Entities;
using Domain.Financial.Entities;
using FluentValidation;

namespace Domain.Identity.Validations;

public class ValidateUserIdValidation : AbstractValidator<CashFlow>
{
    public ValidateUserIdValidation()
    {
        RuleFor(cashFlow => cashFlow.UserId).NotNull().NotEmpty().GreaterThan(0);
    }
}