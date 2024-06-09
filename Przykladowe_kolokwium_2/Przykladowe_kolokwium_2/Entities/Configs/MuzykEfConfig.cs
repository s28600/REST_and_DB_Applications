using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Przykladowe_kolokwium_2.Entities.Configs;

public class MuzykEfConfig : IEntityTypeConfiguration<Muzyk>
{
    public void Configure(EntityTypeBuilder<Muzyk> builder)
    {
        builder.HasKey(e => e.IdMuzyk);
        builder.Property(e => e.IdMuzyk).UseIdentityColumn();
        builder.Property(e => e.Imie).IsRequired().HasMaxLength(30);
        builder.Property(e => e.Nazwisko).IsRequired().HasMaxLength(40);
        builder.Property(e => e.Pseudonim).IsRequired(false).HasMaxLength(50);

        builder.ToTable(nameof(Muzyk));
    }
}