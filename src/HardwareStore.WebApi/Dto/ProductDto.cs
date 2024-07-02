namespace HardwareStore.WebApi.DTO;

/// <summary>
/// Product DTO.
/// </summary>
/// <param name="Id" example="3fa85f64-5717-4562-b3fc-2c963f66afa6">Product ID.</param>
/// <param name="Name" example="Laptop">Product name.</param>
/// <param name="Category" example="Electronics">Product category.</param>
/// <param name="Price" example="999.99">Product price.</param>
/// <param name="AvailableStock" example="50">Available stock of the product.</param>
/// <param name="LastUpdate" example="2024-07-02T14:30:00.00Z">Last update date and time of the product.</param>
/// <param name="Supplier">Supplier information.</param>
/// <param name="ImageId" example="3fa85f64-5717-4562-b3fc-2c963f66afa6">Image id.</param>
public record ProductDto(
    Guid Id,
    string Name,
    string Category,
    decimal Price,
    int AvailableStock,
    DateTime LastUpdate,
    SupplierDto Supplier,
    Guid ImageId);