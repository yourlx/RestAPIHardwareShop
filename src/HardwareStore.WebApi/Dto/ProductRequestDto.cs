namespace HardwareStore.WebApi.DTO;

public class ProductRequestDto
{
    public string Name { get; set; }

    public string Category { get; set; }

    public decimal Price { get; set; }

    public int AvailableStock { get; set; }

    public Guid SupplierId { get; set; }
}