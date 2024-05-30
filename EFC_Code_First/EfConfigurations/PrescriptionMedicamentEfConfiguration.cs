using EFC_Code_First.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFC_Code_First.EfConfigurations;

public class PrescriptionMedicamentEfConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        builder.HasKey(pm => new {pm.IdMedicament, pm.IdPrescription});

        builder.Property(pm => pm.Dose).IsRequired(false);
        builder.Property(pm => pm.Details).IsRequired().HasMaxLength(100);

        builder.HasOne(pm => pm.IdMedicamentNavigation)
            .WithMany(m => m.PrescriptionMedicaments)
            .HasForeignKey(pm => pm.IdMedicament)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(pm => pm.IdPrescriptionNavigation)
            .WithMany(p => p.PrescriptionMedicaments)
            .HasForeignKey(pm => pm.IdPrescription)
            .OnDelete(DeleteBehavior.Cascade);
    }
}