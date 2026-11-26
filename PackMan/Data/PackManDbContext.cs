using Microsoft.EntityFrameworkCore;
using PackMan.Data;
using PackMan.Models;
using System.Reflection.Emit;

namespace PackMan.Data {
  public class PackManDbContext : DbContext {

    public PackManDbContext(DbContextOptions<PackManDbContext> options) : base(options) {

    }


    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Pallet> Pallets => Set<Pallet>();
    public DbSet<Element> Elements => Set<Element>();
    

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);

     

      // Relationen mellem Order og Element
      modelBuilder.Entity<Order>()
      .HasMany(e => e.Elements)
      .WithOne(o => o.Order)
      .HasPrincipalKey(o => o.TransportOrderId)
      .HasForeignKey(e => e.ElementId);

      // Begrænsninger på Order
      modelBuilder.Entity<Order>()
        .Property(o => o.RefOrderId)
        .IsRequired()                       // NOT NULL
        .HasMaxLength(100);                 // NVARCHAR(100)

      // Seed Data
      /*modelBuilder.Entity<Customer>().HasData(
        new Customer { Id = 1, Name = "John Doe" },
        new Customer { Id = 2, Name = "Jane Doe" }
      );*/

      modelBuilder.Entity<Element>()
        .HasKey(e => e.ElementId);

      // Begrænsninger på Element
      modelBuilder.Entity<Element>(entity => {
        entity.Property(e => e.Rotate).IsRequired();
        entity.Property(e => e.RequireSpecialPallet).IsRequired();
        entity.Property(e => e.Length).IsRequired();
        entity.Property(e => e.Width).IsRequired();
        entity.Property(e => e.Height).IsRequired();
        entity.Property(e => e.Weight).IsRequired();
        entity.Property(e => e.Series).IsRequired().HasMaxLength(100);
        entity.Property(e => e.Brand).IsRequired().HasMaxLength(100);
      });

      modelBuilder.Entity<Pallet>()
        .HasKey(e => e.Id);

      // Begrænsninger på Pallet
      modelBuilder.Entity<Pallet>(entity => {
        entity.Property(p => p.Description).IsRequired().HasMaxLength(300);
        entity.Property(p => p.length).IsRequired();
        entity.Property(p => p.width).IsRequired();
        entity.Property(p => p.palletType).IsRequired();
        entity.Property(p => p.Weight).IsRequired();
        entity.Property(p => p.MaxWeight).IsRequired();
        entity.Property(p => p.Overhang).IsRequired();
        entity.Property(p => p.AirBetweenElements).IsRequired();
        entity.Property(p => p.isActive).IsRequired();

      });

    }
  }
}
