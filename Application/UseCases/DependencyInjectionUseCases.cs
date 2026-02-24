using Microsoft.Extensions.DependencyInjection;
using UseCase.UseCases.Interfaces;
using UseCase.UseCases.User;

namespace UseCase.UseCases;

public static class DependencyInjectionUseCases
{
    public static void AddUseCase(this IServiceCollection services)
    {
        services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
        services.AddScoped<IGetUserUseCase, GetUserUseCase>();
    }
}