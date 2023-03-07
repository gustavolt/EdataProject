using EdataProject.Application.Clients.Commands;
using EdataProject.Domain.Entities;
using EdataProject.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EdataProject.Application.Clients.Handlers;

public class ClientCreateCommandHandler : IRequestHandler<ClientCreateCommand, Client>
{
    private readonly IClientRepository _clientRepository;
    public ClientCreateCommandHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }
    public async Task<Client> Handle(ClientCreateCommand request, 
        CancellationToken cancellationToken)
    {
        var client = new Client(request.Name, request.LastName, request.Cpf,
                          request.BirthDate, request.Email);

        if (client == null)
        {
            throw new ApplicationException($"Error creating entity.");
        }
        else
        {
            return await _clientRepository.CreateAsync(client);
        }
    }
}
