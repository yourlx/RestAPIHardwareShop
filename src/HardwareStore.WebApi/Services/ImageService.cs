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
    public async Task<ImageDto> CreateAsync(Guid productId, byte[] content)
    {
        var image = await productRepository.GetAsync(productId);

        if (image.Image is not null)
        {
            throw new ProductHasImageException(
                $"Product with id = {productId} already has image with id = {image.Image.Id}");
        }

        image.Image = new Image
        {
            Id = new Guid(),
            Content = content
        };

        await productRepository.UpdateAsync(image);

        return mapper.Map<Image, ImageDto>(image.Image);
    }

    public async Task UpdateAsync(Guid id, byte[] content)
    {
        await imageRepository.UpdateAsync(new Image { Id = id, Content = content });
    }

    public async Task DeleteAsync(Guid id)
    {
        await imageRepository.DeleteAsync(id);
    }

    public async Task<ImageDto> GetByProductIdAsync(Guid id)
    {
        var image = await productRepository.GetAsync(id);

        if (image.Image is null)
        {
            throw new ImageNotFoundException($"Product with id = {id} has no image!");
        }

        return mapper.Map<ImageDto>(image);
    }

    public async Task<ImageDto> GetAsync(Guid id)
    {
        var image = await imageRepository.GetAsync(id);

        return mapper.Map<ImageDto>(image);
    }
}