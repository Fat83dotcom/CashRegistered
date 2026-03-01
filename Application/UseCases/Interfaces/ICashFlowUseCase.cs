using System.Linq.Expressions;
using Shared.Request;
using Shared.Response;

namespace Application.UseCases.Interfaces;

public interface ICashFlowUseCase
{
    public Task CreateCashFlow(CreateCashFlowRequest request);
    
    public Task<IEnumerable<GetCashFlowsAvailableResponse>> GetCashFlowsAvailable();
}