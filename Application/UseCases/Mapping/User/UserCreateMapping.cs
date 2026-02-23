using AutoMapper;
using UseCase.Request.User;

namespace UseCase.UseCases.Mapping.User;

public class UserCreateMapping : Profile
{
    public UserCreateMapping()
    {
        CreateMap<CreateUserRequest, Domain.Entities.User>();
    }
}