using Application.Identity.Interfaces;
using Application.Security.Interfaces;
using Application.Financial.Interfaces;
using Domain.Security.Interfaces;
using Shared.Identity.Request;
using Shared.Security.Request;
using Shared.Financial.Request;
using Shared.Request;
using Shared.Identity.Response;
using Shared.Security.Response;
using Shared.Financial.Response;


namespace Application.Security.UseCases;

public class AuthAppService(
    IUserUseCase userUseCase,
    ITokenGenerator tokenGenerator,
    IPasswordHasher hasher
) : IAuthAppService
{
    public async Task<LoginUserResponse> Login(LoginRequest request)
    {
        var user = await userUseCase.GetValidUserByUserName(request.UserName);

        if (!user.AuthenticatePassword(hasher, request.Password))
            return new LoginUserResponse();
        
        return new LoginUserResponse
        {
            AccessToken = tokenGenerator.GenerateToken(user),
            Id = user.Id,
            UserName = user.Person.Name,
            Role = user.UserRole.ToString()
        };
    }
}