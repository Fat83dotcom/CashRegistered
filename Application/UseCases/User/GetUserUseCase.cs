using Domain.Repositories.User;
using Shared.Abstractions;
using UseCase.UseCases.Interfaces;

namespace UseCase.UseCases.User;

public class GetUserUseCase(IUserRepository repository, IUnitOfWork unitOfWork) : IGetUserUseCase
{
    public async Task<IEnumerable<Domain.Entities.User>> GetUsers()
    {
        return await repository.FindAsync(u => true);
    }
}