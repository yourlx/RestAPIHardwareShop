using AutoMapper;
using HardwareStore.WebApi.Data;
using HardwareStore.WebApi.DTO;
using HardwareStore.WebApi.Models;

namespace HardwareStore.WebApi.Services;

public class ClientService : IClientService
{
    private readonly IMapper _mapper;
    private readonly IClientRepository _clientRepository;
    private readonly IAddressRepository _addressRepository;

    public ClientService(IMapper mapper, IClientRepository clientRepository, IAddressRepository addressRepository)
    {
        _mapper = mapper;
        _clientRepository = clientRepository;
        _addressRepository = addressRepository;
    }

    public async Task<ClientDto> CreateAsync(CreateClientDto clientDto)
    {
        var client = _mapper.Map<Client>(clientDto);

        client.Id = new Guid();
        client.RegistrationDate = DateTime.UtcNow;

        await _clientRepository.AddAsync(client);

        return _mapper.Map<ClientDto>(client);
    }

    public async Task DeleteAsync(Guid id)
    {
        var client = await _clientRepository.GetAsync(id);

        await _addressRepository.DeleteAsync(client.Address.Id);
        
        await _clientRepository.DeleteAsync(id);
    }

    public async Task<ClientDto> GetByFullNameAsync(string name, string surname)
    {
        var clients = await _clientRepository.GetAsync();
        var client = clients.FirstOrDefault(x => x.Name == name && x.Surname == surname);

        if (client is null)
        {
            throw new ClientNotFoundException($"Client with name = {name} and surname = {surname} was not found!");
        }

        return _mapper.Map<ClientDto>(client);
    }

    public async Task<IEnumerable<ClientDto>> GetAllAsync(int? limit, int? offset)
    {
        // todo: I'll do it later...
        throw new NotImplementedException();
    }

    public async Task UpdateAddressAsync(Guid id, AddressDto newAddressDto)
    {
        var client = await _clientRepository.GetAsync(id);

        var newAddress = _mapper.Map<Address>(newAddressDto);
        newAddress.Id = client.Address.Id;

        await _addressRepository.UpdateAsync(newAddress);
    }
}