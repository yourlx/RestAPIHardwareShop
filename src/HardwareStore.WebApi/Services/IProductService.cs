using HardwareStore.WebApi.DTO;

namespace HardwareStore.WebApi.Services;

public interface IProductService
{
    Task<ProductDto> CreateAsync(CreateProductDto productDto);

    Task UpdateQuantityAsync(Guid id, int reduceQuantity);

    Task<ProductDto> GetAsync(Guid id);

    Task<IEnumerable<ProductDto>> GetAllAsync();

    Task DeleteAsync(Guid id);
}