using System.Linq.Expressions;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Persistence;
using Shared.Response;

namespace Repository.Repositories;

public class CashFlowRepository(CashRegisterDbContext context) : ICashFlowRepository
{
    public async Task CreateAsync(CashFlow entity)
    {
        await context.CashFlows.AddAsync(entity);
    }

    public Task<CashFlow?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CashFlow>> FindAsync(Expression<Func<CashFlow, bool>> predicate)
    {
        return await context.CashFlows
            .Where(predicate)
            .Include(cf => cf.Expenses)
            .Include(cf => cf.User)
            .ToArrayAsync();
    }

    public void Update(CashFlow entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(CashFlow entity)
    {
        throw new NotImplementedException();
    }
}