using AutoMapper;
using EdataProject.Application.DTOs;
using EdataProject.Application.Clients.Commands;

namespace EdataProject.Application.Mappings;

public class DTOToCommandMappingProfile : Profile
{
    public DTOToCommandMappingProfile()
    {
        CreateMap<ClientDTO, ClientCreateCommand>();
        CreateMap<ClientDTO, ClientUpdateCommand>();
    }
}
