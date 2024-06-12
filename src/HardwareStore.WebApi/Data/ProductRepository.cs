using HardwareStore.WebApi.Context;
using HardwareStore.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HardwareStore.WebApi.Data;

public class ProductRepository(HardwareStoreContext context) : IProductRepository
{
    public async Task AddAsync(Product item)
    {
        await context.Products.AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAsync()
    {
        return await context.Products.Include(x => x.Image)
            .Include(x => x.Supplier)
            .ThenInclude(x => x.Address)
            .ToListAsync();
    }

    public async Task<Product> GetAsync(Guid id)
    {
        var product = await context.Products.Include(x => x.Image)
            .Include(x => x.Supplier)
            .ThenInclude(x => x.Address)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (product is null)
        {
            throw new ProductNotFoundException($"Product with id = {id} not found!");
        }

        return product;
    }

    public async Task UpdateAsync(Product item)
    {
        var product = await GetAsync(item.Id);
        
        product.Name = item.Name;
        product.Category = item.Category;
        product.Price = item.Price;
        product.AvailableStock = item.AvailableStock;
        product.LastUpdate = item.LastUpdate;
        product.Supplier = item.Supplier;
        product.Image = item.Image; // before update - delete old?

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await GetAsync(id);

        context.Products.Remove(product);
        await context.SaveChangesAsync();
    }
}