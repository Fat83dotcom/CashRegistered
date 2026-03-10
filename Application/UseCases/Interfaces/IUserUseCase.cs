using Domain.Entities;
using Shared.Request;
using Shared.Response;

namespace Application.UseCases.Interfaces;

public interface IUserUseCase
{
    public Task<CreateResponse> CreateUser(CreateUserRequest request);
    
    public Task DisableUser(int userId);
    
    public Task <IEnumerable<GetAllUsersResponse>> GetAllUsers();
    
    public Task <IEnumerable<User>> GetUsersIncludeCashFlow();
    
    public Task<User?> GetUserById(int userId);
    
    public Task<User> GetValidUserById(int userId);
}