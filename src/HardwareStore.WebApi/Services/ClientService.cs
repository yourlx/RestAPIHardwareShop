using HardwareStore.WebApi.Data;
using HardwareStore.WebApi.DTO;
using HardwareStore.WebApi.Models;

namespace HardwareStore.WebApi.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IAddressRepository _addressRepository;

    public ClientService(IClientRepository clientRepository, IAddressRepository addressRepository)
    {
        _clientRepository = clientRepository;
        _addressRepository = addressRepository;
    }

    public async Task CreateAsync(ClientDto clientDto)
    {
        // todo: automapper or converter?
        var client = new Client()
        {
            Id = new Guid(),
            Name = clientDto.Name,
            Surname = clientDto.Surname,
            Address = new Address()
            {
                Id = new Guid(),
                City = clientDto.Address.City,
                Country = clientDto.Address.Country,
                Street = clientDto.Address.Street,
            },
            Birthday = clientDto.Birthday,
            Gender = clientDto.Gender,
            RegistrationDate = DateTime.UtcNow,
        };

        await _clientRepository.AddAsync(client);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _clientRepository.DeleteAsync(id);
    }

    public async Task<ClientDto> GetByFullNameAsync(string name, string surname)
    {
        var clients = await _clientRepository.GetAsync();
        var client = clients.FirstOrDefault(x => x.Name == name && x.Surname == surname);

        if (client is null)
        {
            throw new ClientNotFoundException($"Client with name = {name} and surname = {surname} not found!");
        }

        // todo: automapper or converter?
        return new ClientDto()
        {
            Address = new AddressDto()
            {
                City = client.Address.City,
                Country = client.Address.Country,
                Street = client.Address.Street,
            },
            Birthday = client.Birthday,
            Gender = client.Gender,
            Name = client.Name,
            Surname = client.Surname,
        };
    }

    public async Task<IEnumerable<ClientDto>> GetAllAsync(int? limit, int? offset)
    {
        // todo: I'll do it later...
        throw new NotImplementedException();
    }

    public async Task UpdateAddressAsync(Guid id, AddressDto newAddress)
    {
        var client = await _clientRepository.GetAsync(id);

        // todo: automapper or converter?
        await _addressRepository.UpdateAsync(new Address()
        {
            Id = client.Address.Id,
            City = newAddress.City,
            Country = newAddress.Country,
            Street = newAddress.Street,
        });
    }
}