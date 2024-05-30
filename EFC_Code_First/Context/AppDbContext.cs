using EFC_Code_First.EfConfigurations;
using EFC_Code_First.Models;
using Microsoft.EntityFrameworkCore;

namespace EFC_Code_First.Context;

public class AppDbContext : DbContext
{
    public AppDbContext() {}
    
    public AppDbContext(DbContextOptions options) : base(options) { }

    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<Medicament> Medicaments { get; set; }
    public virtual DbSet<Prescription> Prescriptions { get; set; }
    public virtual DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DoctorEfConfiguration());
        modelBuilder.ApplyConfiguration(new PatientEfConfiguration());
        modelBuilder.ApplyConfiguration(new MedicamentEfConfiguration());
        modelBuilder.ApplyConfiguration(new PrescriptionEfConfiguration());
        modelBuilder.ApplyConfiguration(new PrescriptionMedicamentEfConfiguration());
    }
}