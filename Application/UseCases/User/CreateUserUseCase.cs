using AutoMapper;
using Domain.Repositories.User;
using UseCase.Request.User;
using UseCase.UseCases.Interfaces;

namespace UseCase.UseCases.User;

public class CreateUserUseCase(IUserRepository repository, IMapper  mapper) : ICreateUserUseCase
{
    public void CreateUser(CreateUserRequest request)
    {
        var entity = mapper.Map<Domain.Entities.User>(request);
        repository.CreateAsync(entity);
    }
}