using Domain.Identity.Entities;
using Domain.Financial.Entities;
using Shared.Abstractions;

namespace Domain.Identity.Repositories;

public interface IPersonRepository : IRepository<Person>
{
    Task<Person?> GetPersonByEmail(string email);
    
    Task<Person?> GetPersonByDocument(string document);
}