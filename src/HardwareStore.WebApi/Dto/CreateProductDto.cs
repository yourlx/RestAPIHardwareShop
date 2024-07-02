namespace HardwareStore.WebApi.DTO;

/// <summary>
/// Create Product DTO.
/// </summary>
/// <param name="Name" example="Laptop">Product name.</param>
/// <param name="Category" example="Electronics">Product category.</param>
/// <param name="Price" example="999.99">Product price.</param>
/// <param name="AvailableStock" example="50">Available stock of the product.</param>
/// <param name="SupplierId" example="3fa85f64-5717-4562-b3fc-2c963f66afa6">ID of the supplier.</param>
public record CreateProductDto(string Name, string Category, decimal Price, int AvailableStock, Guid SupplierId);