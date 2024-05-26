using HardwareStore.WebApi.DTO;

namespace HardwareStore.WebApi.Services;

public interface IProductService
{
    Task<Guid> CreateAsync(ProductRequestDto productDto);

    Task UpdateQuantityAsync(Guid id, int reduceQuantity);

    Task<ProductResponseDto> GetAsync(Guid id);

    Task<IEnumerable<ProductResponseDto>> GetAllAsync();

    Task DeleteAsync(Guid id);
}