using UseCase.Request.User;

namespace UseCase.UseCases.Interfaces;

public interface IUserUseCase
{
    public Task CreateUser(CreateUserRequest request);
    
    public Task <IEnumerable<Domain.Entities.User>> GetUsers();
}