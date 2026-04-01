using Application.UseCases.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using Shared.Abstractions;
using Shared.Request;
using Shared.Response;
using Shared.Validations;
using Shared.ValueObjects;

namespace Application.UseCases;

public class UserUseCase(
    IUserRepository repository,
    IUnitOfWork unitOfWork,
    IPasswordHasher hashServices
) : GeneralValidator, IUserUseCase
{
    public async Task<CreateResponse> CreateUser(CreateUserRequest request)
    {
        User user = new (
            request.Password,
            request.UserName
        );
        
        user.HashPassword(hashServices);
        
        await repository.CreateAsync(user);
        await unitOfWork.CommitAsync();

        return new CreateResponse
        {
            Id = user.Id
        };
    }
    
    public async Task DisableUser(int userId)
    {
        var user = await GetValidUserById(userId);
        
        user.Deactivate();
        
        repository.Update(user);
        await unitOfWork.CommitAsync();
    }

    public async Task<IEnumerable<GetAllUsersResponse>> GetAllUsers()
    {
        var allUsers = await repository.FindAsync(u => u.IsActive);
        var selectedUsers = allUsers.Select(
            user => new GetAllUsersResponse
            {
                Id =  user.Id,
                Name = user.Person.Name,
                Birthdate = user.Person.Birthdate,
                Document = user.Person.Document
            }
        );
        
        return selectedUsers;
    }

    public async Task<IEnumerable<User>> GetUsersIncludeCashFlow()
    {
        return await repository.FindAsync(u => true);
    }

    public async Task<User?> GetUserById(int userId)
    {
        return await repository.GetByIdAsync(userId);
    }

    public async Task<User> GetValidUserById(int userId)
    {
        var user = await GetUserById(userId);
        
        User.ValidateUserExists(user);

        return user!;
    }

    public async Task<User> GetValidUserByEmail(string email)
    {
        var user = await repository.GetUserByEmail(email);
        
        User.ValidateUserExists(user);
        
        return user!;
    }
}