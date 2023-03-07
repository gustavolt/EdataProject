using EdataProject.Domain.Entities;
using MediatR;

namespace EdataProject.Application.Clients.Queries;

public class GetClientByIdQuery : IRequest<Client>
{
    public int Id { get; set; }
    public GetClientByIdQuery(int id)
    {
        Id = id;
    }
}
