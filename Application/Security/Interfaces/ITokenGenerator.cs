using Domain.Identity.Entities;
using Domain.Financial.Entities;

namespace Application.Security.Interfaces;

public interface ITokenGenerator
{
    string GenerateToken(User user);
}