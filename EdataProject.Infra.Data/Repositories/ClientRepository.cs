using EdataProject.Domain.Entities;
using EdataProject.Domain.Interfaces;
using EdataProject.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdataProject.Infra.Data.Repositories;

public class ClientRepository : IClientRepository
{
    private ApplicationDbContext _clientContext;
    public ClientRepository(ApplicationDbContext context)
    {
        _clientContext = context;
    }

    public async Task<Client> CreateAsync(Client client)
    {
        _clientContext.Add(client);
        await _clientContext.SaveChangesAsync();
        return client;
    }

    public async Task<Client> GetByIdAsync(int? id)
    {
        return await _clientContext.Clients.SingleOrDefaultAsync(p => p.Id == id);
    }
    
    public async Task<IEnumerable<Client>> GetClientsAsync()
    {
        return await _clientContext.Clients.ToListAsync();
    }

    public async Task<Client> RemoveAsync(Client client)
    {
        _clientContext.Remove(client);
        await _clientContext.SaveChangesAsync();
        return client;
    }

    public async Task<Client> UpdateAsync(Client client)
    {
        _clientContext.Update(client);
        await _clientContext.SaveChangesAsync();
        return client;
    }
}
