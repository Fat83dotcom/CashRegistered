using Domain.Entities;
using Shared.Request;

namespace Application.UseCases.Interfaces;

public interface IPersonUseCase
{
    Task<CreateResponse> CreatePerson(CreatePersonRequest request);
    
    Task<Person?> GetPersonByEmail(string email);
    
    Task<Person?> GetPersonByDocument(string document);

    Task<IEnumerable<Person>> GetAllPeople();
}