using EdataProject.Application.Clients.Commands;
using EdataProject.Domain.Entities;
using EdataProject.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EdataProject.Application.Clients.Handlers;

public class ClientRemoveCommandHandler : IRequestHandler<ClientRemoveCommand, Client>
{
    private readonly IClientRepository _clientRepository;
    public ClientRemoveCommandHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository ?? throw new
            ArgumentNullException(nameof(clientRepository));
    }

    public async Task<Client> Handle(ClientRemoveCommand request,
        CancellationToken cancellationToken)
    {
        var client = await _clientRepository.GetByIdAsync(request.Id);

        if (client == null)
        {
            throw new ApplicationException($"Entity could not be found.");
        }
        else
        {
            var result = await _clientRepository.RemoveAsync(client);
            return result;
        }
    }
}
