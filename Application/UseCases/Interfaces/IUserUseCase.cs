using Domain.Entities;
using Shared.Request;
using Shared.Response;

namespace Application.UseCases.Interfaces;

public interface IUserUseCase
{
    Task<CreateResponse> CreateUser(CreateUserRequest request);
    
    Task DisableUser(int userId);
    
    Task <IEnumerable<GetAllUsersResponse>> GetAllUsers();
    
    Task<User?> GetUserById(int userId);
    
    Task<User> GetValidUserById(int userId);
    
    Task<User> GetValidUserByEmail(string email);
}