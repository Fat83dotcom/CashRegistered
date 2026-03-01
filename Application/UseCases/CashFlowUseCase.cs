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
    IUserUseCase user,
    ICashFlowRepository repository,
    IUnitOfWork unitOfWork
) : GeneralValidator, ICashFlowUseCase
{
    public async Task CreateCashFlow(CreateCashFlowRequest request)
    {
        var targetUser = await user.GetUserById(request.UserId);
        
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
}