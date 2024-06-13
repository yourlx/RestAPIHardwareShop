namespace HardwareStore.WebApi.DTO;

/// <summary>
/// Supplier DTO.
/// </summary>
/// <param name="Id">Supplier ID.</param>
/// <param name="Name">Supplier name.</param>
/// <param name="Address">Supplier address.</param>
/// <param name="PhoneNumber">Supplier phone number.</param>
public record SupplierDto(Guid Id, string Name, AddressDto Address, string PhoneNumber);