using System.Linq.Expressions;
using Domain.Inventory.Entities;
using Domain.Inventory.Repositories;
using Infrastructure.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Shared.Inventory.Request;
using Shared.Response;

namespace Infrastructure.Inventory.Repositories;

public class UnitOfMeasureRepository(CashRegisterDbContext context) : IUnitOfMeasureRepository
{
    public async Task<PagedResponse<UnitOfMeasure>> SearchAsync(SearchUnitOfMeasureRequest request)
    {
        return await context.UnitsOfMeasure
            .Where(u => string.IsNullOrWhiteSpace(request.Term) || 
                        u.Code.ToLower().Contains(request.Term.ToLower()) || 
                        u.Name.ToLower().Contains(request.Term.ToLower()))
            .ToPagedResponseAsync(request.Page, request.PageSize);
    }

    public async Task CreateAsync(UnitOfMeasure entity)
    {
        await context.UnitsOfMeasure.AddAsync(entity);
    }

    public Task<UnitOfMeasure?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UnitOfMeasure>> FindAsync(Expression<Func<UnitOfMeasure, bool>> predicate)
    {
        return await context.UnitsOfMeasure
            .Where(predicate)
            .ToListAsync();
    }

    public void Update(UnitOfMeasure entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(UnitOfMeasure entity)
    {
        throw new NotImplementedException();
    }
}