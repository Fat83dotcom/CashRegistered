using System.Linq.Expressions;
using Domain.Entities;
using Domain.Repositories.User;
using Repository.Persistence;
using Shared.Abstractions;

namespace Repository.Repositories;

public class UserRepository(CashRegisterDbContext context) :  IUserRepository
{
    public async Task CreateAsync(User entity)
    {
        await context.Users.AddAsync(entity);
    }

    public Task<User?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public void Update(User entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(User entity)
    {
        throw new NotImplementedException();
    }
}