using HardwareStore.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HardwareStore.WebApi.Context;

public class HardwareStoreContext : DbContext
{
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<Image> Images { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Supplier> Suppliers { get; set; } = null!;
    
    public HardwareStoreContext(DbContextOptions options) : base(options)
    {
        // Database.EnsureDeleted();
        Database.EnsureCreated();
    }
}