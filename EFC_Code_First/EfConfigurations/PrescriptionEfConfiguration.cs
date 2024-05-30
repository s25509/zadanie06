using EFC_Code_First.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFC_Code_First.EfConfigurations;

public class PrescriptionEfConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(p => p.IdPrescription);
        builder.Property(p => p.IdDoctor).ValueGeneratedOnAdd();

        builder.Property(p => p.Date).IsRequired();
        builder.Property(p => p.DueDate).IsRequired();

        builder.HasOne(p => p.IdDoctorNavigation)
            .WithMany(d => d.Prescriptions)
            .HasForeignKey(p => p.IdDoctor)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(p => p.IdPatientNavigation)
            .WithMany(pa => pa.Prescriptions)
            .HasForeignKey(p => p.IdPatient)
            .OnDelete(DeleteBehavior.Cascade);
    }
}