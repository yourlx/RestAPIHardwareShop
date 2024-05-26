using AutoMapper;
using HardwareStore.WebApi.Data;
using HardwareStore.WebApi.DTO;
using HardwareStore.WebApi.Models;

namespace HardwareStore.WebApi.Services;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly ISupplierRepository _supplierRepository;

    public ProductService(IMapper mapper, IProductRepository productRepository, ISupplierRepository supplierRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _supplierRepository = supplierRepository;
    }

    public async Task<Guid> CreateAsync(ProductRequestDto productDto)
    {
        var supplier = await _supplierRepository.GetAsync(productDto.SupplierId);

        var product = _mapper.Map<Product>(productDto);

        product.Id = new Guid();
        product.LastUpdate = DateTime.UtcNow;
        product.Supplier = supplier;

        await _productRepository.AddAsync(product);

        return product.Id;
    }

    public async Task UpdateQuantityAsync(Guid id, int reduceQuantity)
    {
        var product = await _productRepository.GetAsync(id);

        if (product.AvailableStock - reduceQuantity < 0)
        {
            throw new ProductNotEnoughException(
                $"Product with {id} has only {product.AvailableStock} units available, but you trying to get {reduceQuantity}");
        }

        product.AvailableStock -= reduceQuantity;

        await _productRepository.UpdateAsync(product);
    }

    public async Task<ProductResponseDto> GetAsync(Guid id)
    {
        var product = await _productRepository.GetAsync(id);

        return _mapper.Map<ProductResponseDto>(product);
    }

    public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAsync();

        var productsDto = products.Select(x => _mapper.Map<ProductResponseDto>(x));

        return productsDto;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _productRepository.DeleteAsync(id);
    }
}