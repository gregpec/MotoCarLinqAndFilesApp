namespace MotoAppmod4App.Data;
using Microsoft.EntityFrameworkCore;

public class MotoAppmod4AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);      
        optionsBuilder.UseInMemoryDatabase("StorageAppDb");
    }
}

