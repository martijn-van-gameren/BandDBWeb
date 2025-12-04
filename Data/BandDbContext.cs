using Microsoft.EntityFrameworkCore;
using BandDBWeb.Models;

namespace BandDBWeb.Data;

public class BandDbContext : DbContext
{
    public BandDbContext(DbContextOptions<BandDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemClient>().HasKey(ic => new
        {
            ic.ItemId,
            ic.ClientId
        });

        modelBuilder.Entity<ItemClient>().HasOne(i => i.Item)
                                            .WithMany(i => i.ItemClients)
                                            .HasForeignKey(i => i.ItemId);

        modelBuilder.Entity<ItemClient>().HasOne(c => c.Client)
                                            .WithMany(c => c.ItemClients)
                                            .HasForeignKey(i => i.ClientId);

        modelBuilder.Entity<Item>().HasData(
            new Item
            {
                Id = 4,
                Name = "Item",
                Price = 200,
                SerialNumberId = 10,
                CategoryId = 6
            }
        );

        modelBuilder.Entity<SerialNumber>().HasData(
            new SerialNumber
            {
                Id = 10,
                ItemId = 4,
                Name = "ITEM10"
            }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 6,
                Name = "Various Items"
            },
            new Category
            {
                Id = 9,
                Name = "Standard Items"
            }
        );

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Item> Items { get; set; }
    public DbSet<SerialNumber> SerialNumbers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<ItemClient> ItemClients { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=banddbweb;User=bandadmin;Password=SomeStrongPassword123!;",
                                new MySqlServerVersion(new Version(10, 11, 0)));
    }
}