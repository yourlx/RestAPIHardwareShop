using AutoMapper;
using HardwareStore.WebApi.Data;
using HardwareStore.WebApi.DTO;
using HardwareStore.WebApi.Models;

namespace HardwareStore.WebApi.Services;

public class ImageService : IImageService
{
    private readonly IMapper _mapper;
    private readonly IImageRepository _imageRepository;
    private readonly IProductRepository _productRepository;

    public ImageService(IMapper mapper, IImageRepository imageRepository, IProductRepository productRepository)
    {
        _mapper = mapper;
        _imageRepository = imageRepository;
        _productRepository = productRepository;
    }

    public async Task<ImageDto> CreateAsync(Guid productId, byte[] content)
    {
        var image = await _productRepository.GetAsync(productId);

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

        await _productRepository.UpdateAsync(image);

        return _mapper.Map<Image, ImageDto>(image.Image);
    }

    public async Task UpdateAsync(Guid id, byte[] content)
    {
        await _imageRepository.UpdateAsync(new Image { Id = id, Content = content });
    }

    public async Task DeleteAsync(Guid id)
    {
        await _imageRepository.DeleteAsync(id);
    }

    public async Task<ImageDto> GetByProductIdAsync(Guid id)
    {
        var image = await _productRepository.GetAsync(id);

        if (image.Image is null)
        {
            throw new ImageNotFoundException($"Product with id = {id} has no image!");
        }

        return _mapper.Map<ImageDto>(image);
    }

    public async Task<ImageDto> GetAsync(Guid id)
    {
        var image = await _imageRepository.GetAsync(id);

        return _mapper.Map<ImageDto>(image);
    }
}