using EFC_Code_First.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFC_Code_First.EfConfigurations;

public class MedicamentEfConfiguration : IEntityTypeConfiguration<Medicament>
{
    public void Configure(EntityTypeBuilder<Medicament> builder)
    {
        builder.ToTable("Medicament");
        
        builder.HasKey(s => s.IdMedicament);
        builder.Property(s => s.IdMedicament).ValueGeneratedOnAdd();

        builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
        builder.Property(s => s.Description).IsRequired().HasMaxLength(100);
        builder.Property(s => s.Type).IsRequired().HasMaxLength(100);
    }
}