using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;

public class EducationContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<Shipment> Shipments { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder); optionsBuilder.UseNpgsql(@"Host=localhost;Database=education;Username=postgres;Password=123456789")
            .UseSnakeCaseNamingConvention()
            .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())).EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().Property(p => p.CustomerId).ValueGeneratedOnAdd();
        modelBuilder.Entity<Delivery>().Property(p => p.DeliveryId).ValueGeneratedOnAdd();
        modelBuilder.Entity<Product>().Property(p => p.ProductId).ValueGeneratedOnAdd();
        modelBuilder.Entity<Shipment>().Property(p => p.ShipmentId).ValueGeneratedOnAdd();

        modelBuilder.Entity<Shipment>().HasOne(au => au.Customer).WithMany(af => af.Shipments);
        modelBuilder.Entity<Shipment>().HasOne(au => au.Product).WithMany(af => af.Shipments);
        modelBuilder.Entity<Delivery>().HasOne(au => au.Product).WithMany(af => af.Deliveries);

    }

}