using Domain.Entities;
using Shared.Request;
using Shared.Response;

namespace UseCase.UseCases.Interfaces;

public interface IUserUseCase
{
    public Task CreateUser(CreateUserRequest request);
    
    public Task <IEnumerable<GetAllUsersResponse>> GetAllUsers();
    
    public Task <IEnumerable<User>> GetUsersIncludeCashFlow();
    
    public Task<User?> GetUserById(int userId);
}