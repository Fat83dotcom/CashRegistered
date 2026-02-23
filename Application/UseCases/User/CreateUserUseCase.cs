using AutoMapper;
using Domain.Repositories.User;
using Shared.Abstractions;
using UseCase.Request.User;
using UseCase.UseCases.Interfaces;

namespace UseCase.UseCases.User;

public class CreateUserUseCase(
    IUserRepository repository,
    IMapper mapper,
    IUnitOfWork unitOfWork
) : ICreateUserUseCase
{
    public async Task CreateUser(CreateUserRequest request)
    {
        var entity = mapper.Map<Domain.Entities.User>(request);
        
        await repository.CreateAsync(entity);
        await unitOfWork.CommitAsync();
    }
}