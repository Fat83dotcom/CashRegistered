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
           .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate)
    {
        return await context.Users
            .Where(predicate)
            .Include(u => u.CashFlow)
            .ToListAsync();
    }

    public void Update(User entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GetAllUsersResponse>> GetUsers()
    {
        throw new NotImplementedException();
    }  
}