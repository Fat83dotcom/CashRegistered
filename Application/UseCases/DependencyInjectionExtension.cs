using Microsoft.Extensions.DependencyInjection;
using UseCase.UseCases.Interfaces;
using UseCase.UseCases.User;

namespace UseCase.UseCases;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
    }
}