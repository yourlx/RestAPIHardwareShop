using HardwareStore.WebApi.Context;
using HardwareStore.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HardwareStore.WebApi.Data;

public class AddressRepository : IAddressRepository
{
    private readonly HardwareStoreContext _context;

    public AddressRepository(HardwareStoreContext context)
    {
        _context = context;
    }
    
    public async Task AddAsync(Address item)
    {
        await _context.Addresses.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Address>> GetAsync()
    {
        return await _context.Addresses.ToListAsync();
    }

    public async Task<Address> GetAsync(Guid id)
    {
        var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);

        if (address is null)
        {
            throw new Exception($"Address with id = {id} not found!");
        }

        return address;
    }

    public async Task UpdateAsync(Address item)
    {
        var address = await GetAsync(item.Id);

        address.City = item.City;
        address.Country = item.Country;
        address.Street = item.Street;
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var address = await GetAsync(id);

        _context.Addresses.Remove(address);
        await _context.SaveChangesAsync();
    }
}