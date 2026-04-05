using Application.Identity.Interfaces;
using Domain.Identity.Entities;
using Domain.Identity.Repositories;
using Shared.Abstractions;
using Shared.Identity.Request;
using Shared.Request;
using Shared.Validations;

namespace Application.Identity.UseCases;

public class PersonUseCase(
    IPersonRepository repository,
    IUnitOfWork unitOfWork) : GeneralValidator, IPersonUseCase
{
    public async Task<CreateResponse> CreatePerson(CreatePersonRequest request)
    {
        var person = new Person(
            request.FirstName,
            request.LastName,
            request.Document,
            request.BirthDate,
            request.Email,
            request.CellPhone,
            request.Phone,
            request.Gender
        );
        var existingPerson = await repository.GetPersonByDocument(person.Document);

        person.ValidateUniquePerson(existingPerson != null);

        await repository.CreateAsync(person);
        await unitOfWork.CommitAsync();

        return new CreateResponse
        {
            Id = person.Id
        };
    }
    public Task<Person?> GetPersonByEmail(string email)
    {
        return repository.GetPersonByEmail(email);
    }

    public Task<Person?> GetPersonByDocument(string document)
    {
        return repository.GetPersonByDocument(document);
    }

    public Task<IEnumerable<Person>> GetAllPeople()
    {
        return repository.FindAsync(p => true);
    }
}