using Domain.Entities;
using UseCase.Request.CashFlow;

namespace UseCase.UseCases.Interfaces;

public interface ICashFlowUseCase
{
    public Task CreateCashFlow(CreateCashFlowRequest request);
}