namespace HardwareStore.WebApi.DTO;

public class CreateClientDto
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public DateOnly Birthday { get; set; }

    public string Gender { get; set; } // todo: enum?

    public AddressDto Address { get; set; }
}