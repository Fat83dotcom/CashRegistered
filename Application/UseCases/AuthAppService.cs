using Application.UseCases.Interfaces;
using Domain.Interfaces;
using Shared.Request;
using Shared.Response;


namespace Application.UseCases;

public class AuthAppService(
    IUserUseCase userUseCase,
    ITokenGenerator tokenGenerator,
    IPasswordHasher hasher
) : IAuthAppService
{
    public async Task<LoginUserResponse> Login(LoginRequest request)
    {
        var user = await userUseCase.GetValidUserByEmail(request.Email);

        if (user.AuthenticatePassword(hasher, request.Password))
        {
            return new LoginUserResponse
            {
                AccessToken = tokenGenerator.GenerateToken(user),
                Id = user.Id,
                UserName = user.Name
            };
        }

        return new LoginUserResponse();

    }
}