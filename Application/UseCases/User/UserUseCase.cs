using AutoMapper;
using Domain.Repositories.User;
using Domain.ValueObjects;
using Shared.Abstractions;
using UseCase.Request.User;
using UseCase.UseCases.Interfaces;

namespace UseCase.UseCases.User;

public class UserUseCase(
    IUserRepository repository,
    IUnitOfWork unitOfWork
) : IUserUseCase
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
    
    public async Task<IEnumerable<Domain.Entities.User>> GetUsers()
    {
        return await repository.FindAsync(u => true);
    }
}