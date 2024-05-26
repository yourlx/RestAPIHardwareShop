namespace HardwareStore.WebApi.Services;

public interface IImageService
{
    Task<Guid> CreateAsync(Guid productId, byte[] content);

    Task UpdateAsync(Guid id, byte[] content);

    Task DeleteAsync(Guid id);

    Task<byte[]> GetByProductIdAsync(Guid productId);

    Task<byte[]> GetAsync(Guid id);
}