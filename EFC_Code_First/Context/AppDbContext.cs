using Microsoft.EntityFrameworkCore;

namespace EFC_Code_First.Context;

public class AppDbContext : DbContext
{
    public AppDbContext() {}
    
    public AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }
}