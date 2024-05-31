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
    private readonly ImageRepository _imageRepository;

    public ProductService(IMapper mapper, IProductRepository productRepository, ISupplierRepository supplierRepository,
        ImageRepository imageRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _supplierRepository = supplierRepository;
        _imageRepository = imageRepository;
    }

    public async Task<ProductDto> CreateAsync(CreateProductDto productDto)
    {
        var supplier = await _supplierRepository.GetAsync(productDto.SupplierId);

        var product = _mapper.Map<Product>(productDto);

        product.Id = new Guid();
        product.LastUpdate = DateTime.UtcNow;
        product.Supplier = supplier;

        await _productRepository.AddAsync(product);

        return _mapper.Map<ProductDto>(product);
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

    public async Task<ProductDto> GetAsync(Guid id)
    {
        var product = await _productRepository.GetAsync(id);

        return _mapper.Map<ProductDto>(product);
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAsync();

        var productsDto = products.Select(x => _mapper.Map<ProductDto>(x));

        return productsDto;
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await _productRepository.GetAsync(id);

        if (product.Image is not null)
        {
            await _imageRepository.DeleteAsync(product.Image.Id);
        }

        await _productRepository.DeleteAsync(id);
    }
}