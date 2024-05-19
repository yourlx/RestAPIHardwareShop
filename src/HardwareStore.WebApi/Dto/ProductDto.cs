namespace HardwareStore.WebApi.DTO;

public class ProductDto
{
    public string Name { get; set; }

    public string Category { get; set; }

    public decimal Price { get; set; }

    public int Available { get; set; }

    public DateTime LastUpdate { get; set; }

    public SupplierDto Supplier { get; set; }

    public ImageDto Image { get; set; }
}