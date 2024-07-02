namespace HardwareStore.WebApi.DTO;

/// <summary>
/// Supplier DTO.
/// </summary>
/// <param name="Id" example="3fa85f64-5717-4562-b3fc-2c963f66afa6">Supplier ID.</param>
/// <param name="Name" example="Tech Supplies Ltd.">Supplier name.</param>
/// <param name="Address">Supplier address.</param>
/// <param name="PhoneNumber" example="+78005553536">Supplier phone number.</param>
public record SupplierDto(Guid Id, string Name, AddressDto Address, string PhoneNumber);