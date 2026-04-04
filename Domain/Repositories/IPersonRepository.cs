using Domain.Entities;
using Shared.Abstractions;

namespace Domain.Repositories;

public interface IPersonRepository : IRepository<Person>
{
    Task<Person?> GetPersonByEmail(string email);
    
    Task<Person?> GetPersonByDocument(string document);
}