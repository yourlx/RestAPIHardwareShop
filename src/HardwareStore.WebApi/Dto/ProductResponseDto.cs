using HardwareStore.WebApi.Models;

namespace HardwareStore.WebApi.DTO;

public class ProductResponseDto
{
    public string Name { get; set; }

    public string Category { get; set; }

    public decimal Price { get; set; }

    public int AvailableStock { get; set; }

    public DateTime LastUpdate { get; set; }

    public Supplier Supplier { get; set; }

    public ImageDto? Image { get; set; }
}