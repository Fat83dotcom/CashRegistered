using Shared.Request;

namespace Application.UseCases.Interfaces;

public interface ILoginAppService
{
    Task<string> Login(LoginRequest request);
}