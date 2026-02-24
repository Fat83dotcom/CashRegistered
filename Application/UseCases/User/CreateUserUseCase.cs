using AutoMapper;
using Domain.Repositories.User;
using Domain.ValueObjects;
using Shared.Abstractions;
using UseCase.Request.User;
using UseCase.UseCases.Interfaces;

namespace UseCase.UseCases.User;

public class CreateUserUseCase(
    IUserRepository repository,
    IUnitOfWork unitOfWork
) : ICreateUserUseCase
{
    public async Task CreateUser(CreateUserRequest request)
    {
        Name name = new (request.FirstName,
            request.LastName
        );
        Domain.Entities.User user = new (name,
            request.BirthDate,
            request.Document
        );
        
        await repository.CreateAsync(user);
        await unitOfWork.CommitAsync();
    }
}