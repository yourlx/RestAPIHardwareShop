using AutoMapper;
using HardwareStore.WebApi.Data;
using HardwareStore.WebApi.DTO;
using HardwareStore.WebApi.Models;

namespace HardwareStore.WebApi.Services;

public class SupplierService : ISupplierService
{
    private readonly IMapper _mapper;
    private readonly ISupplierRepository _supplierRepository;
    private readonly IAddressRepository _addressRepository;

    public SupplierService(IMapper mapper, ISupplierRepository supplierRepository, IAddressRepository addressRepository)
    {
        _mapper = mapper;
        _supplierRepository = supplierRepository;
        _addressRepository = addressRepository;
    }

    public async Task<Guid> CreateAsync(SupplierDto supplierDto)
    {
        var supplier = _mapper.Map<Supplier>(supplierDto);

        supplier.Id = new Guid();

        await _supplierRepository.AddAsync(supplier);

        return supplier.Id;
    }

    public async Task UpdateAddressAsync(Guid id, AddressDto newAddressDto)
    {
        var supplier = await _supplierRepository.GetAsync(id);

        var newAddress = _mapper.Map<Address>(newAddressDto);
        newAddress.Id = supplier.Address.Id;

        await _addressRepository.UpdateAsync(newAddress);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _supplierRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<SupplierDto>> GetAllAsync()
    {
        var suppliers = await _supplierRepository.GetAsync();

        var suppliersDto = suppliers.Select(x => _mapper.Map<SupplierDto>(x));

        return suppliersDto;
    }

    public async Task<SupplierDto> GetAsync(Guid id)
    {
        var supplier = await _supplierRepository.GetAsync(id);

        return _mapper.Map<SupplierDto>(supplier);
    }
}