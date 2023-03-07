using EdataProject.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdataProject.Application.Interfaces;

public interface IClientService
{
    Task<IEnumerable<ClientDTO>> GetClients();
    Task<ClientDTO> GetById(int? id);

    Task Add(ClientDTO clientDto);
    Task Update(ClientDTO clientDto);
    Task Remove(int? id);
}
