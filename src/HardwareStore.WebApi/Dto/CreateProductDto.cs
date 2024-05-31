namespace HardwareStore.WebApi.DTO;

public class CreateProductDto
{
    public string Name { get; set; }

    public string Category { get; set; }

    public decimal Price { get; set; }

    public int AvailableStock { get; set; }

    public Guid SupplierId { get; set; }
}