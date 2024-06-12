using HardwareStore.WebApi.Context;
using HardwareStore.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HardwareStore.WebApi.Data;

public class AddressRepository(HardwareStoreContext context) : IAddressRepository
{
    public async Task AddAsync(Address item)
    {
        await context.Addresses.AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Address>> GetAsync()
    {
        return await context.Addresses.ToListAsync();
    }

    public async Task<Address> GetAsync(Guid id)
    {
        var address = await context.Addresses.FirstOrDefaultAsync(x => x.Id == id);

        if (address is null)
        {
            throw new AddressNotFoundException($"Address with id = {id} not found!");
        }

        return address;
    }

    public async Task UpdateAsync(Address item)
    {
        var address = await GetAsync(item.Id);
        
        address.Country = item.Country;
        address.City = item.City;
        address.Street = item.Street;
        
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var address = await GetAsync(id);

        context.Addresses.Remove(address);
        await context.SaveChangesAsync();
    }
}