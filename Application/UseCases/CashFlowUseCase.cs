using System.Linq.Expressions;
using Application.UseCases.Interfaces;
using Domain.Entities;
using Domain.Repositories;
using Shared.Abstractions;
using Shared.Request;
using Shared.Response;
using Shared.Validations;

namespace Application.UseCases;

public class CashFlowUseCase(
    IUserUseCase userUseCase,
    ICashFlowRepository repository,
    IUnitOfWork unitOfWork
) : GeneralValidator, ICashFlowUseCase
{
    public async Task CreateCashFlow(CreateCashFlowRequest request)
    {
        var targetUser = await userUseCase.GetUserById(request.UserId);
        
        User.UserExists(targetUser);
        
        var cashFlow = new CashFlow(request.UserId);
        
        cashFlow.CashFlowLinkedToUser(targetUser);
        
        await repository.CreateAsync(cashFlow);
        
        await unitOfWork.CommitAsync();
    }

    public async Task<IEnumerable<GetCashFlowsAvailableResponse>> GetCashFlowsAvailable()
    {
        var result = await repository.FindAsync(cashFlow => true);

        var response = result.Select(c => new GetCashFlowsAvailableResponse()
            {
                Id = c.Id,
                UserId =  c.UserId,
                UserName = c.User!.Name,
                CurrentBalance = c.CurrentBalance
            }
        );
        return response;
    }

    public async Task<IEnumerable<CashFlow>> GetCashFlows()
    {
        return await repository.FindAsync(cashFlow => true);
    }

    public async Task<CashFlow?> GetCashFlowById(int cashFlowId)
    {
        return await repository.GetByIdAsync(cashFlowId);
    }

    public void UpdateCashFlow(CashFlow cashFlow)
    {
        repository.Update(cashFlow);
    }

    public Task<GetExpensesByCashFlowId> GetExpensesByCashFlowId(int cashFlowId)
    {
        throw new NotImplementedException();
    }
}