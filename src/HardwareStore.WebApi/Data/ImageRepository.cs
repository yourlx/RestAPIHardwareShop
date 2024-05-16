using HardwareStore.WebApi.Context;
using HardwareStore.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HardwareStore.WebApi.Data;

public class ImageRepository : IImageRepository
{
    private readonly HardwareStoreContext _context;

    public ImageRepository(HardwareStoreContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Image item)
    {
        await _context.Images.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Image>> GetAsync()
    {
        return await _context.Images.ToListAsync();
    }

    public async Task<Image> GetAsync(Guid id)
    {
        var image = await _context.Images.FirstOrDefaultAsync(x => x.Id == id);

        if (image is null)
        {
            throw new Exception($"Image with id = {id} not found!");
        }

        return image;
    }

    public async Task UpdateAsync(Image item)
    {
        var image = await GetAsync(item.Id);

        image.Content = item.Content;
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var image = await GetAsync(id);

        _context.Images.Remove(image);
        await _context.SaveChangesAsync();
    }
}