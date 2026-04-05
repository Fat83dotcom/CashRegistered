using Domain.Financial.Entities;
using Shared.Financial.Request;
using Shared.Financial.Response;

namespace Application.Financial.Interfaces;

public interface ICashFlowUseCase
{
    public Task CreateCashFlow(CreateCashFlowRequest request);
    
    public Task<IEnumerable<GetCashFlowsAvailableResponse>> GetCashFlowsAvailable();
    
    public Task<CashFlow?> GetCashFlowById(int cashFlowId);
    
    public void UpdateCashFlow(CashFlow cashFlow);
    
    public Task<IEnumerable<GetExpensesByCashFlowIdResponse>> GetExpensesByCashFlowId(int cashFlowId);
    
    public Task AddCash(AddCashRequest request);
}