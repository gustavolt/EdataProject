using EdataProject.Domain.Entities;
using MediatR;

namespace EdataProject.Application.Clients.Commands;

public class ClientRemoveCommand : IRequest<Client>
{
    public int Id { get; set; }
    public ClientRemoveCommand(int id)
    {
        Id = id;
    }
}
