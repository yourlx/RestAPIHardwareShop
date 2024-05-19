namespace HardwareStore.WebApi.Models;

public class Supplier
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Address Address { get; set; }

    public string PhoneNumber { get; set; }
}