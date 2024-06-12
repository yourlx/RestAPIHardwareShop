using HardwareStore.WebApi.Context;
using HardwareStore.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HardwareStore.WebApi.Data;

public class ImageRepository(HardwareStoreContext context) : IImageRepository
{
    public async Task AddAsync(Image item)
    {
        await context.Images.AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Image>> GetAsync()
    {
        return await context.Images.ToListAsync();
    }

    public async Task<Image> GetAsync(Guid id)
    {
        var image = await context.Images.FirstOrDefaultAsync(x => x.Id == id);

        if (image is null)
        {
            throw new ImageNotFoundException($"Image with id = {id} not found!");
        }

        return image;
    }

    public async Task UpdateAsync(Image item)
    {
        var image = await GetAsync(item.Id);
        
        image.Content = item.Content;

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var image = await GetAsync(id);

        context.Images.Remove(image);

        await context.SaveChangesAsync();
    }
}