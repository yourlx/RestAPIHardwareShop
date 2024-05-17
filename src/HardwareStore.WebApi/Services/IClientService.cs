using HardwareStore.WebApi.DTO;

namespace HardwareStore.WebApi.Services;

public interface IClientService
{
    Task CreateAsync(ClientDto clientDto);
    
    Task DeleteAsync(Guid id);
    
    Task<ClientDto> GetByFullNameAsync(string name, string surname);
    
    Task<IEnumerable<ClientDto>> GetAllAsync(int? limit, int? offset);
    
    Task UpdateAddressAsync(Guid id, AddressDto newAddress);
}