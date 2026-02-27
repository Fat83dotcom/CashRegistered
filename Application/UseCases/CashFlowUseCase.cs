using Domain.Entities;
using Domain.Repositories;
using Shared.Abstractions;
using Shared.Request;
using Shared.Validations;
using UseCase.UseCases.Interfaces;

namespace UseCase.UseCases;

public class CashFlowUseCase(
    IUserUseCase user,
    ICashFlowRepository repository,
    IUnitOfWork unitOfWork
) : GeneralValidator, ICashFlowUseCase
{
    public async Task CreateCashFlow(CreateCashFlowRequest request)
    {
        var cashFlow = new CashFlow(request.UserId);
        
        var targetUser = await user.GetUserById(request.UserId);
        
        cashFlow.CashFlowLinkedToUser(targetUser);
        
        await repository.CreateAsync(cashFlow);
        
        await unitOfWork.CommitAsync();
    }
}