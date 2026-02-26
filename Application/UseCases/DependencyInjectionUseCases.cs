using Microsoft.Extensions.DependencyInjection;
using UseCase.UseCases.Interfaces;

namespace UseCase.UseCases;

public static class DependencyInjectionUseCases
{
    public static void AddUseCase(this IServiceCollection services)
    {
        services.AddScoped<IUserUseCase, UserUseCase>();
        
        services.AddScoped<ICashFlowUseCase, CashFlowUseCase>();
    }
}