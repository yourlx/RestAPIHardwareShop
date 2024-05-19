namespace HardwareStore.WebApi.Models;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Category { get; set; }

    public decimal Price { get; set; }

    public int Available { get; set; }

    public DateTime LastUpdate { get; set; }

    public Supplier Supplier { get; set; }

    public Image Image { get; set; }
}