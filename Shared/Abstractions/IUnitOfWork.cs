namespace Shared.Abstractions;

public interface IUnitOfWork
{
    Task<bool> CommitAsync();
}