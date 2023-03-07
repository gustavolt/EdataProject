using EdataProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdataProject.Domain.Interfaces;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetClientsAsync();
    Task<Client> GetByIdAsync(int? id);

    Task<Client> CreateAsync(Client client);
    Task<Client> UpdateAsync(Client client);
    Task<Client> RemoveAsync(Client client);
}

