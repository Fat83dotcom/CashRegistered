using Domain.Entities;
using Domain.Repositories.User;
using Shared.Abstractions;
using Shared.Validations;
using UseCase.Request.CashFlow;
using UseCase.UseCases.Interfaces;

namespace UseCase.UseCases;

public class CashFlowUseCase(
    IUserUseCase user,
    ICashFlowRepositoy repository,
    IUnitOfWork unitOfWork
) : GeneralValidator, ICashFlowUseCase
{
    public async Task CreateCashFlow(CreateCashFlowRequest request)
    {
        var cashFlow = new CashFlow(request.UserId);
        
        var users = await user.GetUsersIncludeCashFlow();
        
        cashFlow.CashFlowLinkedToAnotherUser(users);
        
        await repository.CreateAsync(cashFlow);
        
        await unitOfWork.CommitAsync();
    }
}