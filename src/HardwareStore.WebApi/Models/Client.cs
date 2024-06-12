namespace HardwareStore.WebApi.Models;

public class Client
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public DateOnly Birthday { get; set; }

    public string Gender { get; set; }

    public DateTime RegistrationDate { get; set; }

    public Address Address { get; set; }
}