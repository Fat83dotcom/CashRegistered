using Domain.Entities;
using Shared.Response;
using UseCase.Request.User;

namespace UseCase.UseCases.Interfaces;

public interface IUserUseCase
{
    public Task CreateUser(CreateUserRequest request);
    
    public Task <IEnumerable<GetAllUsersResponse>> GetAllUsers();
    
    public Task <IEnumerable<User>> GetUsersIncludeCashFlow();
}