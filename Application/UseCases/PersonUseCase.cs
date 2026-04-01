using Application.UseCases.Interfaces;
using Shared.Request;
using Shared.Validations;

namespace Application.UseCases;

public class PersonUseCase : GeneralValidator, IPersonUseCase
{
    public Task<CreateResponse> CreatePerson(CreatePersonRequest request)
    {
        throw new NotImplementedException();
    }
}