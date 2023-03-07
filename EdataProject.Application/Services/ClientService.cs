using AutoMapper;
using EdataProject.Application.DTOs;
using EdataProject.Application.Interfaces;
using EdataProject.Application.Clients.Commands;
using EdataProject.Application.Clients.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdataProject.Application.Services;

public class ClientService : IClientService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    public ClientService(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<IEnumerable<ClientDTO>> GetClients()
    {
        var clientsQuery = new GetClientsQuery();

        if (clientsQuery == null)
            throw new Exception($"Entity could not be loaded.");

        var result = await _mediator.Send(clientsQuery);

        return _mapper.Map<IEnumerable<ClientDTO>>(result);
    }

    public async Task<ClientDTO> GetById(int? id)
    {
        var clientByIdQuery = new GetClientByIdQuery(id.Value);

        if (clientByIdQuery == null)
            throw new Exception($"Entity could not be loaded.");

        var result = await _mediator.Send(clientByIdQuery);

        return _mapper.Map<ClientDTO>(result);
    }

    public async Task Add(ClientDTO clientDto)
    {
        var clientCreateCommand = _mapper.Map<ClientCreateCommand>(clientDto);
        await _mediator.Send(clientCreateCommand);
    }

    public async Task Update(ClientDTO clientDto)
    {
        var clientUpdateCommand = _mapper.Map<ClientUpdateCommand>(clientDto);
        await _mediator.Send(clientUpdateCommand);
    }

    public async Task Remove(int? id)
    {
        var clientRemoveCommand = new ClientRemoveCommand(id.Value);
        if (clientRemoveCommand == null)
            throw new Exception($"Entity could not be loaded.");

        await _mediator.Send(clientRemoveCommand);
    }
}
