using System.Linq.Expressions;
using Domain.Identity.Entities;
using Domain.Identity.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;

namespace Infrastructure.Identity.Repositories;

public class PersonRepository(CashRegisterDbContext context) : IPersonRepository
{
    public async Task CreateAsync(Person entity)
    {
        await context.People.AddAsync(entity);
    }

    public async Task<Person?> GetByIdAsync(int id)
    {
        return await context.People
            .Where(p => p.Id == id)
            .Include(p => p.Addresses)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Person>> FindAsync(Expression<Func<Person, bool>> predicate)
    {
        return await context.People
            .Where(predicate)
            .Include(p => p.Addresses)
            .ToListAsync();
    }

    public void Update(Person entity)
    {
        context.People.Update(entity);
    }

    public void Delete(Person entity)
    {
        context.People.Remove(entity);
    }

    public async Task<Person?> GetPersonByEmail(string email)
    {
        return await context.People
            .Where(p => p.Email == email)
            .FirstOrDefaultAsync();
    }

    public async Task<Person?> GetPersonByTaxId(string taxId)
    {
        return await context.People
            .Where(p => p.TaxId == taxId)
            .FirstOrDefaultAsync();
    }
}
