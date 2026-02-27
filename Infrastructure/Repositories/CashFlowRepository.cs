using System.Linq.Expressions;
using Domain.Entities;
using Domain.Repositories;
using Repository.Persistence;

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

    public Task<IEnumerable<CashFlow>> FindAsync(Expression<Func<CashFlow, bool>> predicate)
    {
        throw new NotImplementedException();
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