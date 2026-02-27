using Domain.Entities;
using Shared.Request;

namespace UseCase.UseCases.Interfaces;

public interface ICashFlowUseCase
{
    public Task CreateCashFlow(CreateCashFlowRequest request);
}