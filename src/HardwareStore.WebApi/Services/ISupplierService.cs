using HardwareStore.WebApi.DTO;

namespace HardwareStore.WebApi.Services;

public interface ISupplierService
{
    Task<SupplierDto> CreateAsync(CreateSupplierDto supplierDto);

    Task UpdateAddressAsync(Guid id, AddressDto newAddressDto);

    Task DeleteAsync(Guid id);

    Task<IEnumerable<SupplierDto>> GetAllAsync();

    Task<SupplierDto> GetAsync(Guid id);
}