using EdataProject.Application.Clients.Commands;
using EdataProject.Domain.Entities;
using EdataProject.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EdataProject.Application.Clients.Handlers;

public class ClientUpdateCommandHandler : IRequestHandler<ClientUpdateCommand, Client>
{
    private readonly IClientRepository _clientRepository;
    public ClientUpdateCommandHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository ??
        throw new ArgumentNullException(nameof(clientRepository));
    }

    public async Task<Client> Handle(ClientUpdateCommand request,
        CancellationToken cancellationToken)
    {
        var client = await _clientRepository.GetByIdAsync(request.Id);

        if (client == null)
        {
            throw new ApplicationException($"Entity could not be found.");
        }
        else
        {
            client.Update(request.Name, request.LastName, request.Cpf,
                            request.BirthDate, request.Email);

            return await _clientRepository.UpdateAsync(client);

        }
    }
}
