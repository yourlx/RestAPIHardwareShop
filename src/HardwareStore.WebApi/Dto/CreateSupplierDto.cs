namespace HardwareStore.WebApi.DTO;

/// <summary>
/// Create Supplier DTO.
/// </summary>
/// <param name="Name">Supplier name.</param>
/// <param name="Address">Supplier address.</param>
/// <param name="PhoneNumber">Supplier phone number.</param>
public record CreateSupplierDto(string Name, AddressDto Address, string PhoneNumber);