namespace HardwareStore.WebApi.Models;

public class Supplier
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid AddressId { get; set; } // todo: one to one, one to many?
    public string PhoneNumber { get; set; } // todo: type?
}