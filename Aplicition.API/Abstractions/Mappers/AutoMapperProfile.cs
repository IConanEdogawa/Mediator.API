using AutoMapper;
using Mediator.Applicition.CreateUserMediator.Command;
using Mediator.Domain.Entities;

namespace Mediator.Applicition.Abstractions.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<User, CreateUserCommand>().ReverseMap();

        }
    }
}
