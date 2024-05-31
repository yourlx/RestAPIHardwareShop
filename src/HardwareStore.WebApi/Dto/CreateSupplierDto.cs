namespace HardwareStore.WebApi.DTO;

public class CreateSupplierDto
{
    public string Name { get; set; }
    
    public AddressDto Address { get; set; }
    
    public string PhoneNumber { get; set; }
}