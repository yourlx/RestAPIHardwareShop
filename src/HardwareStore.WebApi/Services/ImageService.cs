using AutoMapper;
using HardwareStore.WebApi.Data;
using HardwareStore.WebApi.DTO;
using HardwareStore.WebApi.Models;

namespace HardwareStore.WebApi.Services;

public class ImageService(
    IMapper mapper,
    IImageRepository imageRepository,
    IProductRepository productRepository)
    : IImageService
{
    public async Task<Guid> CreateAsync(Guid productId, byte[] content)
    {
        var product = await productRepository.GetAsync(productId);

        if (product.Image is not null)
        {
            throw new ProductHasImageException(
                $"Product with id = {productId} already has image with id = {product.Image.Id}");
        }

        product.Image = new Image
        {
            Id = new Guid(),
            Content = content
        };

        await productRepository.UpdateAsync(product);

        return product.Image.Id;
    }

    public async Task UpdateAsync(Guid id, byte[] content)
    {
        await imageRepository.UpdateAsync(new Image { Id = id, Content = content });
    }

    public async Task DeleteAsync(Guid id)
    {
        var products = await productRepository.GetAsync();

        var productContainedImage = products.FirstOrDefault(x => x.Image?.Id == id);
        if (productContainedImage is not null)
        {
            productContainedImage.Image = null;
        }
        
        await imageRepository.DeleteAsync(id);
    }

    public async Task<ImageDto> GetByProductIdAsync(Guid id)
    {
        var product = await productRepository.GetAsync(id);

        if (product.Image is null)
        {
            throw new ImageNotFoundException($"Product with id = {id} has no image!");
        }

        return mapper.Map<ImageDto>(product.Image);
    }

    public async Task<ImageDto> GetAsync(Guid id)
    {
        var image = await imageRepository.GetAsync(id);

        return mapper.Map<ImageDto>(image);
    }
}