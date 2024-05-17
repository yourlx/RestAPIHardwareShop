namespace HardwareStore.WebApi.DTO;

public class ClientDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
    public string Gender { get; set; } // todo: enum?
    public AddressDto Address { get; set; }
}