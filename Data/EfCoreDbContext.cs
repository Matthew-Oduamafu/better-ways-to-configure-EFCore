using Better.Way.To.Configure.EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Better.Way.To.Configure.EFCore.Data;

public class EfCoreDbContext : DbContext
{
    public EfCoreDbContext(DbContextOptions<EfCoreDbContext> options):base(options)
    {
        
    }
    public DbSet<Car> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Car>().HasData(
            new Car()
            {
                Id = 1,
                Model = "Toyota Corolla",
                Company = "Toyota"
            }
        );
    }
}