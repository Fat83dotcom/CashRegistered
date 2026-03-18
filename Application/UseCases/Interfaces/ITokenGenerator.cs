using Domain.Entities;

namespace Application.UseCases.Interfaces;

public interface ITokenGenerator
{
    string GenerateToken(User user);
}