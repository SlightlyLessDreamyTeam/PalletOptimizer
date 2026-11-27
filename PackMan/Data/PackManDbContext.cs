using Microsoft.EntityFrameworkCore;
using PackMan.Data;
using PackMan.Models;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PackMan.Data {
  public class PackManDbContext : IdentityDbContext<AppUser> {

    public PackManDbContext(DbContextOptions<PackManDbContext> options) : base(options) {

    }


    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Pallet> Pallets => Set<Pallet>();
    public DbSet<Element> Elements => Set<Element>();
    

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Order>(entity =>
      {
        entity.HasKey(o => o.TransportOrderId);
        entity.HasMany(o => o.Elements).WithOne(e => e.Order).HasForeignKey(e => e.TransportOrderId);
        entity.Property(o => o.RefOrderId).IsRequired();
      });

      // Relationen mellem Order og Element
     // modelBuilder.Entity<Order>()
      
     
      

      // Begrænsninger på Order
     //modelBuilder.Entity<Order>()
                               // NOT NULL
    

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
