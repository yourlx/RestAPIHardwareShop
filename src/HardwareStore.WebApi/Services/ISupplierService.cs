using HardwareStore.WebApi.DTO;

namespace HardwareStore.WebApi.Services;

public interface ISupplierService
{
    Task<Guid> CreateAsync(SupplierDto supplierDto);

    Task UpdateAddressAsync(Guid id, AddressDto newAddressDto);

    Task DeleteAsync(Guid id);

    Task<IEnumerable<SupplierDto>> GetAllAsync();

    Task<SupplierDto> GetAsync(Guid id);
}