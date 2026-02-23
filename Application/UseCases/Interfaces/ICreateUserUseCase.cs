using UseCase.Request.User;

namespace UseCase.UseCases.Interfaces;

public interface ICreateUserUseCase
{
    public void CreateUser(CreateUserRequest request);
}