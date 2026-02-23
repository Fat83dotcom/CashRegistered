using UseCase.Request.User;

namespace UseCase.UseCases.Interfaces;

public interface ICreateUserUseCase
{
    public Task CreateUser(CreateUserRequest request);
}