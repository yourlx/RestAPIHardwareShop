using HardwareStore.WebApi.Context;
using HardwareStore.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HardwareStore.WebApi.Data;

public class SupplierRepository(HardwareStoreContext context) : ISupplierRepository
{
    public async Task AddAsync(Supplier item)
    {
        await context.Suppliers.AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Supplier>> GetAsync()
    {
        return await context.Suppliers.Include(x => x.Address).ToListAsync();
    }

    public async Task<Supplier> GetAsync(Guid id)
    {
        var supplier = await context.Suppliers.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);

        if (supplier is null)
        {
            throw new SupplierNotFoundException($"Supplier with id = {id} not found!");
        }

        return supplier;
    }

    public async Task UpdateAsync(Supplier item)
    {
        var supplier = await GetAsync(item.Id);

        supplier.Name = item.Name;
        supplier.Address = item.Address; // before update - delete old?
        supplier.PhoneNumber = item.PhoneNumber;

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var supplier = await GetAsync(id);

        context.Suppliers.Remove(supplier);
        await context.SaveChangesAsync();
    }
}