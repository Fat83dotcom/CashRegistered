using Application.UseCases.Interfaces;
using Domain.Interfaces;
using Shared.Request;


namespace Application.UseCases;

public class LoginAppService(
    IUserUseCase userUseCase,
    ITokenGenerator tokenGenerator,
    IPasswordHasher hasher
) : ILoginAppService
{
    public async Task<string> Login(LoginRequest request)
    {
        var user = await userUseCase.GetValidUserByEmail(request.Email);
    
        return user.AuthenticatePassword(hasher, request.Password)
            ? tokenGenerator.GenerateToken(user)
            : string.Empty;
    }
}