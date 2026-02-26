using Domain.Repositories;
using Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Persistence;
using Repository.Repositories;
using Shared.Abstractions;

namespace Repository;

public static class DependencyInjectionInfrastructure
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        // 1. Configura o Banco de Dados (Postgres)
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<CashRegisterDbContext>(options =>
            options.UseNpgsql(connectionString)); 

        // Dentro do método AddInfrastructure
        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<CashRegisterDbContext>());
        
        // Injeta os Repositórios (Linka a Interface com a Implementação)
        services.AddScoped<IUserRepository, UserRepository>();
        
        services.AddScoped<ICashFlowRepositoy, CashFlowRepository>();

        return services;
    }
}