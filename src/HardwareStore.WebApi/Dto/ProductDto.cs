namespace HardwareStore.WebApi.DTO;

/// <summary>
/// Product DTO.
/// </summary>
/// <param name="Id">Product ID.</param>
/// <param name="Name">Product name.</param>
/// <param name="Category">Product category.</param>
/// <param name="Price">Product price.</param>
/// <param name="AvailableStock">Available stock of the product.</param>
/// <param name="LastUpdate">Last update date and time of the product.</param>
/// <param name="Supplier">Supplier information.</param>
/// <param name="Image">Image information.</param>
public record ProductDto(
    Guid Id,
    string Name,
    string Category,
    decimal Price,
    int AvailableStock,
    DateTime LastUpdate,
    SupplierDto Supplier,
    ImageDto? Image);