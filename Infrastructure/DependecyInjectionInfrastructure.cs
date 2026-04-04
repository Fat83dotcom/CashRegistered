using Domain.Interfaces;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Persistence;
using Repository.Repositories;
using Repository.Security;
using Shared.Abstractions;

namespace Repository;

public static class DependencyInjectionInfrastructure
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<CashRegisterDbContext>(options =>
            options.UseNpgsql(connectionString)); 
        
        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<CashRegisterDbContext>());

        services.AddScoped<IPasswordHasher, Argon2Services>();
       
        services.AddScoped<IUserRepository, UserRepository>();
        
        services.AddScoped<ICashFlowRepository, CashFlowRepository>();
        
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        
        services.AddScoped<IPersonRepository, PersonRepository>();

        return services;
    }
}