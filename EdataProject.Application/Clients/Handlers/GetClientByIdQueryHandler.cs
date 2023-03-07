using EdataProject.Application.Clients.Queries;
using EdataProject.Domain.Entities;
using EdataProject.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EdataProject.Application.Clients.Handlers;

public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, Client>
{
    private readonly IClientRepository _clientRepository;
    public GetClientByIdQueryHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<Client> Handle(GetClientByIdQuery request,
         CancellationToken cancellationToken)
    {
        return await _clientRepository.GetByIdAsync(request.Id);
    }
}
