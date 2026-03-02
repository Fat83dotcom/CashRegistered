using Application.UseCases.Interfaces;
using Domain.Entities;
using Domain.Repositories;
using Shared.Abstractions;
using Shared.Request;
using Shared.Validations;

namespace Application.UseCases;

public class ExpenseUseCase(
    IExpenseRepository expenseRepository,
    IUserUseCase userUseCase,
    ICashFlowUseCase cashFlowUseCase,
    IUnitOfWork unitOfWork
) : GeneralValidator, IExpenseUseCase
{
    public async Task CreateExpense(CreateExpenseRequest request)
    {
        var user = await userUseCase.GetUserById(request.UserId);
        
        User.ValidateUserExists(user);
        
        user!.ValidateUserHasCashFlow();
        
        user.ValidateUserIdMatchCashFlow(request.CashFlowId);

        var newExpense = new Expense(
            request.ExpenseDescription,
            request.ExpenseValue,
            request.CashFlowId
        );
        
        await expenseRepository.CreateAsync(newExpense);

        var cashFlow = await cashFlowUseCase.GetCashFlowById(request.CashFlowId);
        
        cashFlow!.DecreaseCurrentBalance(request.ExpenseValue);
        
        cashFlowUseCase.UpdateCashFlow(cashFlow);

        await unitOfWork.CommitAsync();
    }
}