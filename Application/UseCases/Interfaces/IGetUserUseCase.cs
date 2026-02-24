namespace UseCase.UseCases.Interfaces;

public interface IGetUserUseCase
{
    public Task <IEnumerable<Domain.Entities.User>> GetUsers();
}