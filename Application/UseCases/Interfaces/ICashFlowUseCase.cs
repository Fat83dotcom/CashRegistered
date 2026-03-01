using Domain.Entities;
using Shared.Request;
using Shared.Response;

namespace Application.UseCases.Interfaces;

public interface ICashFlowUseCase
{
    public Task CreateCashFlow(CreateCashFlowRequest request);
    
    public Task<IEnumerable<GetCashFlowsAvailableResponse>> GetCashFlowsAvailable();
    
    public Task<IEnumerable<CashFlow>> GetCashFlows();
    
    public Task<CashFlow?> GetCashFlowById(int cashFlowId);
    
    public void UpdateCashFlow(CashFlow cashFlow);
    
    public Task<GetExpensesByCashFlowId> GetExpensesByCashFlowId(int cashFlowId);
}