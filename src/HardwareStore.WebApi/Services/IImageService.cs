using HardwareStore.WebApi.DTO;

namespace HardwareStore.WebApi.Services;

public interface IImageService
{
    Task<Guid> CreateAsync(Guid productId, byte[] content);

    Task UpdateAsync(Guid id, byte[] content);

    Task DeleteAsync(Guid id);

    Task<ImageDto> GetByProductIdAsync(Guid productId);

    Task<ImageDto> GetAsync(Guid id);
}