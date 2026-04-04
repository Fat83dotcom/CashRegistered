using System.Linq.Expressions;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Persistence;
using Shared.Response;

namespace Repository.Repositories;

public class UserRepository(CashRegisterDbContext context) : IUserRepository
{
    public async Task CreateAsync(User entity)
    {
        await context.Users.AddAsync(entity);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
       return await context.Users
           .Where(u => u.Id == id)
           .Include(u => u.CashFlow)
           .Include(u => u.Person)
           .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate)
    {
        return await context.Users
            .Where(predicate)
            .Include(u => u.CashFlow)
            .Include(u => u.Person)
            .ToListAsync();
    }

    public void Update(User entity)
    {
        context.Users.Update(entity);
    }

    public void Delete(User entity)
    {
        context.Users.Remove(entity);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await context.Users
            .Include(u => u.Person)
            .Where(u => u.Person.Email == email)
            .FirstOrDefaultAsync();
    }

    public async Task<User?> GetUserByUserName(string userName)
    {
        return await context.Users
            .Include(u => u.Person)
            .Where(u => u.UserName == userName)
            .FirstOrDefaultAsync();
    }
}