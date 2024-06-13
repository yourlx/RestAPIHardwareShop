namespace HardwareStore.WebApi.DTO;

/// <summary>
/// Create Product DTO.
/// </summary>
/// <param name="Name">Product name.</param>
/// <param name="Category">Product category.</param>
/// <param name="Price">Product price.</param>
/// <param name="AvailableStock">Available stock of the product.</param>
/// <param name="SupplierId">ID of the supplier.</param>
public record CreateProductDto(string Name, string Category, decimal Price, int AvailableStock, Guid SupplierId);