using AutoMapper;
using HardwareStore.WebApi.Data;
using HardwareStore.WebApi.DTO;
using HardwareStore.WebApi.Models;

namespace HardwareStore.WebApi.Services;

public class ClientService(
    IMapper mapper,
    IClientRepository clientRepository,
    IAddressRepository addressRepository)
    : IClientService
{
    public async Task<ClientDto> CreateAsync(CreateClientDto clientDto)
    {
        var client = mapper.Map<Client>(clientDto);

        client.Id = new Guid();
        client.RegistrationDate = DateTime.UtcNow;

        await clientRepository.AddAsync(client);

        return mapper.Map<ClientDto>(client);
    }

    public async Task DeleteAsync(Guid id)
    {
        var client = await clientRepository.GetAsync(id);

        await addressRepository.DeleteAsync(client.Address.Id);

        await clientRepository.DeleteAsync(id);
    }

    public async Task<ClientDto> GetByFullNameAsync(string name, string surname)
    {
        var clients = await clientRepository.GetAsync();
        var client = clients.FirstOrDefault(x => x.Name == name && x.Surname == surname);

        if (client is null)
        {
            throw new ClientNotFoundException($"Client with name = {name} and surname = {surname} was not found!");
        }

        return mapper.Map<ClientDto>(client);
    }

    public async Task<IEnumerable<ClientDto>> GetAllAsync(int? limit, int? offset)
    {
        var clients = await clientRepository.GetAsync();

        if (offset.HasValue)
        {
            clients = clients.Skip(offset.Value);
        }

        if (limit.HasValue)
        {
            clients = clients.Take(limit.Value);
        }

        var clientsDto = clients.Select(mapper.Map<ClientDto>);

        return clientsDto;
    }

    public async Task UpdateAddressAsync(Guid id, AddressDto newAddressDto)
    {
        var client = await clientRepository.GetAsync(id);

        var newAddress = mapper.Map<Address>(newAddressDto);
        newAddress.Id = client.Address.Id;

        await addressRepository.UpdateAsync(newAddress);
    }
}