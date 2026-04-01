using Shared.Request;

namespace Application.UseCases.Interfaces;

public interface IPersonUseCase
{
    Task<CreateResponse> CreatePerson(CreatePersonRequest request);
}