namespace HardwareStore.WebApi.DTO;

public class ClientDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public DateOnly Birthday { get; set; }

    public string Gender { get; set; }
    
    // public DateTime RegistrationDate { get; set; } // uncomment or delete?

    public AddressDto Address { get; set; }
}