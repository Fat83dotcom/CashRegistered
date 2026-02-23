using Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Persistence;
using Repository.Repositories;

namespace Repository;

public static class DependencyInjection
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

        // 2. Injeta os Repositórios (Linka a Interface com a Implementação)
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}