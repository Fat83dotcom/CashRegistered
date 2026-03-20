using Shared.Request;
using Shared.Response;

namespace Application.UseCases.Interfaces;

public interface IAuthAppService
{
    Task<LoginUserResponse> Login(LoginRequest request);
}