using AutoMapper;
using HardwareStore.WebApi.Data;
using HardwareStore.WebApi.DTO;
using HardwareStore.WebApi.Models;

namespace HardwareStore.WebApi.Services;

public class ProductService(
    IMapper mapper,
    IProductRepository productRepository,
    ISupplierRepository supplierRepository,
    IImageRepository imageRepository)
    : IProductService
{
    public async Task<ProductDto> CreateAsync(CreateProductDto productDto)
    {
        var supplier = await supplierRepository.GetAsync(productDto.SupplierId);

        var product = mapper.Map<Product>(productDto);

        product.Id = new Guid();
        product.LastUpdate = DateTime.UtcNow;
        product.Supplier = supplier;

        await productRepository.AddAsync(product);

        return mapper.Map<ProductDto>(product);
    }

    public async Task UpdateQuantityAsync(Guid id, int reduceQuantity)
    {
        var product = await productRepository.GetAsync(id);

        if (product.AvailableStock - reduceQuantity < 0)
        {
            throw new ProductNotEnoughException(
                $"Product with {id} has only {product.AvailableStock} units available, but you trying to get {reduceQuantity}");
        }

        product.AvailableStock -= reduceQuantity;

        await productRepository.UpdateAsync(product);
    }

    public async Task<ProductDto> GetAsync(Guid id)
    {
        var product = await productRepository.GetAsync(id);

        return mapper.Map<ProductDto>(product);
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await productRepository.GetAsync();

        var productsDto = products.Select(mapper.Map<ProductDto>);

        return productsDto;
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await productRepository.GetAsync(id);

        if (product.Image is not null)
        {
            await imageRepository.DeleteAsync(product.Image.Id);
        }

        await productRepository.DeleteAsync(id);
    }
}