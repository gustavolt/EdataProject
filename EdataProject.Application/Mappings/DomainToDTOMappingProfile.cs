using AutoMapper;
using EdataProject.Application.DTOs;
using EdataProject.Domain.Entities;

namespace EdataProject.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Client, ClientDTO>().ReverseMap();
    }
}
