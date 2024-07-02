namespace HardwareStore.WebApi.DTO;

/// <summary>
/// Create Supplier DTO.
/// </summary>
/// <param name="Name" example="Tech Supplies Ltd.">Supplier name.</param>
/// <param name="Address">Supplier address.</param>
/// <param name="PhoneNumber" example="+78005553536">Supplier phone number.</param>
public record CreateSupplierDto(string Name, AddressDto Address, string PhoneNumber);