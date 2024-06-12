using System.Text.RegularExpressions;
using AutoMapper;
using HardwareStore.WebApi.Data;
using HardwareStore.WebApi.DTO;
using HardwareStore.WebApi.Models;

namespace HardwareStore.WebApi.Services;

public class SupplierService(
    IMapper mapper,
    ISupplierRepository supplierRepository,
    IAddressRepository addressRepository)
    : ISupplierService
{
    private static readonly string _phoneNumberPattern = @"^\+7\d{10}$";

    public async Task<SupplierDto> CreateAsync(CreateSupplierDto supplierDto)
    {
        var correctNumber = Regex.IsMatch(supplierDto.PhoneNumber, _phoneNumberPattern);
        if (!correctNumber)
        {
            throw new PhoneNumberFormatException("Wrong phone number format!");
        }

        var supplier = mapper.Map<Supplier>(supplierDto);

        supplier.Id = new Guid();

        await supplierRepository.AddAsync(supplier);

        return mapper.Map<SupplierDto>(supplier);
    }

    public async Task UpdateAddressAsync(Guid id, AddressDto newAddressDto)
    {
        var supplier = await supplierRepository.GetAsync(id);

        var newAddress = mapper.Map<Address>(newAddressDto);
        newAddress.Id = supplier.Address.Id;

        await addressRepository.UpdateAsync(newAddress);
    }

    public async Task DeleteAsync(Guid id)
    {
        var supplier = await supplierRepository.GetAsync(id);

        await addressRepository.DeleteAsync(supplier.Address.Id);

        await supplierRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<SupplierDto>> GetAllAsync()
    {
        var suppliers = await supplierRepository.GetAsync();

        var suppliersDto = suppliers.Select(mapper.Map<SupplierDto>);

        return suppliersDto;
    }

    public async Task<SupplierDto> GetAsync(Guid id)
    {
        var supplier = await supplierRepository.GetAsync(id);

        return mapper.Map<SupplierDto>(supplier);
    }
}