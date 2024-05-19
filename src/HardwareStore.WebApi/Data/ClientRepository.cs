using HardwareStore.WebApi.Context;
using HardwareStore.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HardwareStore.WebApi.Data;

public class ClientRepository : IClientRepository
{
    private readonly HardwareStoreContext _context;

    public ClientRepository(HardwareStoreContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Client item)
    {
        await _context.Clients.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Client>> GetAsync()
    {
        return await _context.Clients.Include(x => x.Address).ToListAsync();
    }

    public async Task<Client> GetAsync(Guid id)
    {
        var client = await _context.Clients.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);

        if (client is null)
        {
            throw new ClientNotFoundException($"Client with id = {id} not found!");
        }

        return client;
    }

    public async Task UpdateAsync(Client item)
    {
        var client = await GetAsync(item.Id);

        // todo: remake?
        client.Birthday = item.Birthday;
        client.Gender = item.Gender;
        client.Name = item.Name;
        client.Address = item.Address;
        client.Surname = item.Surname;
        client.RegistrationDate = item.RegistrationDate;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var client = await GetAsync(id);

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
    }
}