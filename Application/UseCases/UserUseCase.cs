using Application.UseCases.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Repositories;
using Shared.Abstractions;
using Shared.Request;
using Shared.Response;
using Shared.Validations;

namespace Application.UseCases;

public class UserUseCase(
    IUserRepository repository,
    IPersonRepository personRepository,
    IPersonUseCase personUseCase,
    IUnitOfWork unitOfWork,
    IPasswordHasher hashServices
) : GeneralValidator, IUserUseCase
{
    public async Task<CreateResponse> CreateUser(CreateUserRequest request)
    {
        int personId;
        
        if (request.PersonId > 0)
        {
            var person = await personRepository.GetByIdAsync(request.PersonId.Value);
            Person.ValidatePersonExists(person);
            personId = person!.Id;
        }
        else
        {
            var createPersonRequest = new CreatePersonRequest
            {
                FirstName = request.FirstName!,
                LastName = request.LastName!,
                BirthDate = request.BirthDate ?? DateTime.MinValue,
                Document = request.Document!,
                Email = request.Email!,
                CellPhone = request.CellPhone!,
                Phone = request.Phone!,
                Gender = request.Gender!
            };

            var personResponse = await personUseCase.CreatePerson(createPersonRequest);
            personId = personResponse.Id;
        }
        
        var existingUserByUsername = await repository.GetUserByUserName(request.UserName);
        
        var usersForPerson = await repository.FindAsync(u => u.PersonId == personId);
        var personAlreadyHasUser = usersForPerson.Any();
        
        var userRole = Enum.TryParse(request.Role, out UserRole role) ? role : UserRole.Business;
        
        User user = new (
            personId,
            request.Password,
            request.UserName,
            userRole
        );
        
        user.ValidateUniqueUser(existingUserByUsername != null, personAlreadyHasUser);
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

    public async Task ChangePassword(int userId, ChangePasswordRequest request)
    {
        var user = await GetValidUserById(userId);

        user.AuthenticatePassword(hashServices, request.OldPassword);

        user.UpdatePassword(request.NewPassword, hashServices);

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

    public async Task<User> GetValidUserByUserName(string userName)
    {
        var user = await repository.GetUserByUserName(userName);
        
        User.ValidateUserExists(user);
        
        return user!;
    }
}
