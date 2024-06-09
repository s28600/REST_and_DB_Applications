using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Przykladowe_kolokwium_2.Entities.Configs;

public class WykonawcaUtworuEtConfig : IEntityTypeConfiguration<WykonawcaUtworu>
{
    public void Configure(EntityTypeBuilder<WykonawcaUtworu> builder)
    {
        builder.HasKey(e => new { e.IdMuzyk, e.IdUtwor });

        builder.HasOne(e => e.Muzyk)
            .WithMany(e => e.Utwory)
            .HasForeignKey(e => e.IdMuzyk);
        builder.HasOne(e => e.Utwor)
            .WithMany(e => e.Muzycy)
            .HasForeignKey(e => e.IdUtwor);

        builder.ToTable(nameof(WykonawcaUtworu));
    }
}