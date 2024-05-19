namespace HardwareStore.WebApi.Models;

public class Client
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public DateTime Birthday { get; set; }

    public string Gender { get; set; } // todo: enum?

    public DateTime RegistrationDate { get; set; }

    public Address Address { get; set; }
}