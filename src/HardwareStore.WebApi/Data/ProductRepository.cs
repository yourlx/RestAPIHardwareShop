using HardwareStore.WebApi.Context;
using HardwareStore.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HardwareStore.WebApi.Data;

public class ProductRepository : IProductRepository
{
    private readonly HardwareStoreContext _context;

    public ProductRepository(HardwareStoreContext context)
    {
        _context = context;
    }
    
    public async Task AddAsync(Product item)
    {
        await _context.Products.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetAsync(Guid id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

        if (product is null)
        {
            throw new Exception($"Product with id = {id} not found!");
        }

        return product;
    }

    public async Task UpdateAsync(Product item)
    {
        var product = await GetAsync(item.Id);

        product.Available = item.Available;
        product.Category = item.Category;
        product.ImageId = item.ImageId;
        product.Name = item.Name;
        product.Price = item.Price;
        product.LastUpdate = item.LastUpdate;
        product.SupplierId = item.SupplierId;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await GetAsync(id);

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}