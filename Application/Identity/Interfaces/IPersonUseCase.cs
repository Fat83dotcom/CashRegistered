using Domain.Identity.Entities;
using Domain.Financial.Entities;
using Shared.Identity.Request;
using Shared.Security.Request;
using Shared.Financial.Request;
using Shared.Request;

namespace Application.Identity.Interfaces;

public interface IPersonUseCase
{
    Task<CreateResponse> CreatePerson(CreatePersonRequest request);
    
    Task<Person?> GetPersonByEmail(string email);
    
    Task<Person?> GetPersonByTaxId(string taxId);

    Task<IEnumerable<Person>> GetAllPeople();
}