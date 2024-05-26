using HardwareStore.WebApi.Context;
using HardwareStore.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HardwareStore.WebApi.Data;

public class SupplierRepository : ISupplierRepository
{
    private readonly HardwareStoreContext _context;

    public SupplierRepository(HardwareStoreContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Supplier item)
    {
        // todo: add check for phone number?

        await _context.Suppliers.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Supplier>> GetAsync()
    {
        return await _context.Suppliers.Include(x => x.Address).ToListAsync();
    }

    public async Task<Supplier> GetAsync(Guid id)
    {
        var supplier = await _context.Suppliers.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);

        if (supplier is null)
        {
            throw new SupplierNotFoundException($"Supplier with id = {id} not found!");
        }

        return supplier;
    }

    public async Task UpdateAsync(Supplier item)
    {
        var supplier = await GetAsync(item.Id);

        // todo: remake?
        supplier.Name = item.Name;
        supplier.Address = item.Address;
        supplier.PhoneNumber = item.PhoneNumber;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var supplier = await GetAsync(id);

        _context.Suppliers.Remove(supplier);
        await _context.SaveChangesAsync();
    }
}