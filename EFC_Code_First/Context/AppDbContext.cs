using EFC_Code_First.EfConfigurations;
using Microsoft.EntityFrameworkCore;

namespace EFC_Code_First.Context;

public class AppDbContext : DbContext
{
    public AppDbContext() {}
    
    public AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DoctorEfConfiguration());
        modelBuilder.ApplyConfiguration(new PatientEfConfiguration());
        modelBuilder.ApplyConfiguration(new MedicamentEfConfiguration());
        modelBuilder.ApplyConfiguration(new PrescriptionEfConfiguration());
        modelBuilder.ApplyConfiguration(new PrescriptionMedicamentEfConfiguration());
    }
}