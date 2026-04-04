using Application.UseCases.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases;

public static class DependencyInjectionUseCases
{
    public static void AddUseCase(this IServiceCollection services)
    {
        services.AddScoped<IUserUseCase, UserUseCase>();
        
        services.AddScoped<ICashFlowUseCase, CashFlowUseCase>();
        
        services.AddScoped<IExpenseUseCase, ExpenseUseCase>();
        
        services.AddScoped<IAuthAppService, AuthAppService>();
        
        services.AddScoped<ITokenGenerator, TokenService>();
        
        services.AddScoped<IPersonUseCase, PersonUseCase>();
    }
}