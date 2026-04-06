using Application.Identity.Interfaces;
using Application.Security.Interfaces;
using Domain.Identity.Entities;
using Domain.Identity.Enums;
using Domain.Security.Interfaces;
using Domain.Identity.Repositories;
using Shared.Abstractions;
using Shared.Identity.Request;
using Shared.Security.Request;
using Shared.Request;
using Shared.Identity.Response;
using Shared.Response;
using Shared.Notifications;
using Shared.Validations;

namespace Application.Identity.UseCases;

public class UserUseCase(
    IUserRepository repository,
    IPersonRepository personRepository,
    IPersonUseCase personUseCase,
    IUnitOfWork unitOfWork,
    IPasswordHasher hashServices,
    NotificationContext notificationContext
) : GeneralValidator, IUserUseCase
{
    public async Task<CreateResponse> CreateUser(CreateUserRequest request)
    {
        int personId;
        
        if (request.PersonId > 0)
        {
            var person = await personRepository.GetByIdAsync(request.PersonId.Value);
            if (person == null)
            {
                notificationContext.AddNotification("Person", "A pessoa informada não existe.");
                return new CreateResponse();
            }
            personId = person.Id;
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

        if (user.IsInvalid)
        {
            notificationContext.AddNotifications(user.Notifications);
            return new CreateResponse();
        }

        user.HashPassword(hashServices);
        
        await repository.CreateAsync(user);
        await unitOfWork.CommitAsync();

        return new CreateResponse { Id = user.Id };
    }
    
    public async Task DisableUser(int userId)
    {
        var user = await repository.GetByIdAsync(userId);
        if (user == null)
        {
            notificationContext.AddNotification("User", "O usuário não existe.");
            return;
        }
        
        user.Deactivate();
        
        repository.Update(user);
        await unitOfWork.CommitAsync();
    }

    public async Task ChangePassword(int userId, ChangePasswordRequest request)
    {
        var user = await repository.GetByIdAsync(userId);
        if (user == null)
        {
            notificationContext.AddNotification("User", "O usuário não existe.");
            return;
        }

        if (!user.AuthenticatePassword(hashServices, request.OldPassword))
        {
            notificationContext.AddNotifications(user.Notifications);
            return;
        }

        user.UpdatePassword(request.NewPassword, hashServices);

        if (user.IsInvalid)
        {
            notificationContext.AddNotifications(user.Notifications);
            return;
        }

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
        User.ValidateUserExists(user, notificationContext);
        return user!;
    }

    public async Task<User> GetValidUserByEmail(string email)
    {
        var user = await repository.GetUserByEmail(email);
        User.ValidateUserExists(user, notificationContext);
        return user!;
    }

    public async Task<User?> GetUserByUserName(string userName)
    {
        var user = await repository.GetUserByUserName(userName);
        User.ValidateUserExists(user, notificationContext);
        return user!;
    }

    public async Task<User?> GetUserLoginByUserName(string userName)
    {
        var user = await repository.GetUserByUserName(userName);
        User.ValidateUserLoginExists(user, notificationContext);
        return user;
    }

    public async Task<PagedResponse<GetAllUsersResponse>> SearchUsers(SearchUserRequest request)
    {
        var pagedUsers = await repository.SearchAsync(request);
        
        return new PagedResponse<GetAllUsersResponse>
        {
            Items = pagedUsers.Items.Select(u => new GetAllUsersResponse
            {
                Id = u.Id,
                Name = u.Person.Name,
                Birthdate = u.Person.Birthdate,
                Document = u.Person.Document
            }),
            TotalCount = pagedUsers.TotalCount,
            Page = pagedUsers.Page,
            PageSize = pagedUsers.PageSize
        };
    }
}

