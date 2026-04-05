using Domain.Identity.Entities;
using Domain.Financial.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Abstractions;
using Flunt.Notifications;

namespace Infrastructure.Persistence;

public class CashRegisterDbContext(DbContextOptions<CashRegisterDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<User> Users { get; set; }

    public DbSet<CashFlow> CashFlows { get; set; }

    public DbSet<Expense> Expenses { get; set; }

    public DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Notification>();

        // Aplica todas as configurações (Configurations) definidas neste assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CashRegisterDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> CommitAsync() => await SaveChangesAsync() > 0;
}