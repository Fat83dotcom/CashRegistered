using Application.UseCases.Interfaces;
using Domain.Entities;
using Domain.Repositories;
using Shared.Abstractions;
using Shared.Request;
using Shared.Validations;

namespace Application.UseCases;

public class ExpenseUseCase(
    IExpenseRepository expenseRepository,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork
) : GeneralValidator, IExpenseUseCase
{
    public async Task CreateExpense(CreateExpenseRequest request)
    {
        var user = await userRepository.GetByIdAsync(request.UserId);
        
        User.UserExists(user);
        
        user!.UserIdMatchCashFlow(request.CashFlowId);

        var newExpense = new Expense(
            request.ExpenseDescription,
            request.ExpenseValue,
            request.UserId
        );
    }
}