using Domain.Entities;
using Domain.Repositories;
using Domain.Repositories.User;
using Shared.Abstractions;
using Shared.Response;
using Shared.ValueObjects;
using UseCase.Request.User;
using UseCase.UseCases.Interfaces;

namespace UseCase.UseCases;

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
        Domain.Entities.User user = new (
            name,
            request.BirthDate,
            request.Document
        );
        
        await repository.CreateAsync(user);
        await unitOfWork.CommitAsync();
    }

    public async Task<IEnumerable<GetAllUsersResponse>> GetAllUsers()
    {
        var allUsers = await repository.FindAsync(u => true);
        IEnumerable<GetAllUsersResponse> selectedUsers = allUsers.Select(
            user => new GetAllUsersResponse
            {
                Name = user.Name,
                Birthdate = user.Birthdate,
                Document = user.Document
            }
        );
        
        return selectedUsers;
    }

    public async Task<IEnumerable<User>> GetUsersIncludeCashFlow()
    {
        return await repository.FindAsync(u => true);
    }
}