using HardwareStore.WebApi.Context;
using HardwareStore.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HardwareStore.WebApi.Data;

public class ClientRepository(HardwareStoreContext context) : IClientRepository
{
    public async Task AddAsync(Client item)
    {
        await context.Clients.AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Client>> GetAsync()
    {
        return await context.Clients.Include(x => x.Address).ToListAsync();
    }

    public async Task<Client> GetAsync(Guid id)
    {
        var client = await context.Clients.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);

        if (client is null)
        {
            throw new ClientNotFoundException($"Client with id = {id} not found!");
        }

        return client;
    }

    public async Task UpdateAsync(Client item)
    {
        var client = await GetAsync(item.Id);
        
        client.Name = item.Name;
        client.Surname = item.Surname;
        client.Birthday = item.Birthday;
        client.Gender = item.Gender;
        client.RegistrationDate = item.RegistrationDate;
        client.Address = item.Address; // before update - delete old?

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var client = await GetAsync(id);

        context.Clients.Remove(client);
        await context.SaveChangesAsync();
    }
}