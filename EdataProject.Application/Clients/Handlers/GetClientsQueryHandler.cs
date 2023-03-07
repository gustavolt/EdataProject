using EdataProject.Application.Clients.Queries;
using EdataProject.Domain.Entities;
using EdataProject.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EdataProject.Application.Clients.Handlers;

public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, IEnumerable<Client>>
{
    private readonly IClientRepository _clientRepository;

    public GetClientsQueryHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<IEnumerable<Client>> Handle(GetClientsQuery request, 
        CancellationToken cancellationToken)
    {
        return await _clientRepository.GetClientsAsync();
    }
}
