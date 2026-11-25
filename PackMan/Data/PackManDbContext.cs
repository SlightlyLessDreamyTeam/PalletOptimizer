using Microsoft.EntityFrameworkCore;
using PackMan.Data;
using System.Reflection.Emit;

namespace PackMan.Data {
  public class PackManDbContext : DbContext {

    public PackManDbContext(DbContextOptions<PackManDbContext> options) : base(options) {

    }
}
    /*
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Instructor> Instructors => Set<Instructor>();
    public DbSet<Course> Courses => Set<Course>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Student>(entity =>
      {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Name).IsRequired();
        entity.Property(e => e.Education).IsRequired();
        entity.Property(e => e.Semester).IsRequired();
        entity.Property(e => e.Email).IsRequired();

      });


    }
  }*/
}
