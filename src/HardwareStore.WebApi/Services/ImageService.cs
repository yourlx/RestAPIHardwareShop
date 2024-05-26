using HardwareStore.WebApi.Data;
using HardwareStore.WebApi.Models;

namespace HardwareStore.WebApi.Services;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;
    private readonly IProductRepository _productRepository;

    public ImageService(IImageRepository imageRepository, IProductRepository productRepository)
    {
        _imageRepository = imageRepository;
        _productRepository = productRepository;
    }

    public async Task<Guid> CreateAsync(Guid productId, byte[] content)
    {
        var product = await _productRepository.GetAsync(productId);

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

        await _productRepository.UpdateAsync(product);

        return product.Image.Id;
    }

    public async Task UpdateAsync(Guid id, byte[] content)
    {
        await _imageRepository.UpdateAsync(new Image { Id = id, Content = content });
    }

    public async Task DeleteAsync(Guid id)
    {
        await _imageRepository.DeleteAsync(id);
    }

    public async Task<byte[]> GetByProductIdAsync(Guid id)
    {
        var product = await _productRepository.GetAsync(id);

        if (product.Image is null)
        {
            throw new ImageNotFoundException($"Product with id = {id} has no image!");
        }

        return product.Image.Content;
    }

    public async Task<byte[]> GetAsync(Guid id)
    {
        var image = await _imageRepository.GetAsync(id);

        return image.Content;
    }
}