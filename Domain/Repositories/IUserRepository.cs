using Shared.Abstractions;
using Shared.Response;

namespace Domain.Repositories;

public interface IUserRepository : IRepository<Entities.User>
{
    public Task<IEnumerable<GetAllUsersResponse>> GetUsers();
}