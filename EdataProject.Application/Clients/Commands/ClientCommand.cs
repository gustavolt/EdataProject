using EdataProject.Domain.Entities;
using MediatR;

namespace EdataProject.Application.Clients.Commands;

public abstract class ClientCommand : IRequest<Client>
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Cpf { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Email { get; set; }
}
