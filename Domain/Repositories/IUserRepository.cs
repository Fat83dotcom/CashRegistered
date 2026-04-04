using Domain.Entities;
using Shared.Abstractions;

namespace Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetUserByEmail(string email);
    
    Task<User?> GetUserByUserName(string userName);
}