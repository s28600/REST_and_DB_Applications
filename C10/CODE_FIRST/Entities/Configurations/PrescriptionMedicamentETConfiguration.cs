using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CODE_FIRST.Entities.Configurations;

public class PrescriptionMedicamentETConfiguration : IEntityTypeConfiguration<Prescription_Medicament>
{
    public void Configure(EntityTypeBuilder<Prescription_Medicament> builder)
    {
        builder.HasKey(e => new { e.IdMedicament, e.IdPrescription });
        builder.Property(e => e.Details).IsRequired().HasMaxLength(100);
        builder.HasOne(e => e.Medicament)
            .WithMany(e => e.PrescriptionMedicaments)
            .HasConstraintName("PrescriptionMedicament_Medicament")
            .HasForeignKey(e => e.IdMedicament)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Prescription)
            .WithMany(e => e.PrescriptionMedicaments)
            .HasConstraintName("PrescriptionMedicament_Prescription")
            .HasForeignKey(e => e.IdPrescription)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(nameof(Prescription_Medicament));
    }
}