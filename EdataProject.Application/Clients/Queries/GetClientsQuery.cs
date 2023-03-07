using EdataProject.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace EdataProject.Application.Clients.Queries
{
    public class GetClientsQuery : IRequest<IEnumerable<Client>>
    {
    }
}
