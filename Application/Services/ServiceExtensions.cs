using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services;

public static class ServiceExtensions
{
    public static void ConfigurationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(
            cfg => { }, Assembly.GetExecutingAssembly()
        );
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}