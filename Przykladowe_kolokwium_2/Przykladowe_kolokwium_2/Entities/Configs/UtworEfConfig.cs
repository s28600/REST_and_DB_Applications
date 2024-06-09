using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Przykladowe_kolokwium_2.Entities.Configs;

public class UtworEfConfig : IEntityTypeConfiguration<Utwor>
{
    public void Configure(EntityTypeBuilder<Utwor> builder)
    {
        builder.HasKey(e => e.IdUtwor);
        builder.Property(e => e.IdUtwor).UseIdentityColumn();
        builder.Property(e => e.NazwaUtworu).IsRequired().HasMaxLength(30);
        builder.Property(e => e.CzasTrwania).IsRequired();
        builder.Property(e => e.IdAlbum).IsRequired(false);

        builder.HasOne(e => e.Album)
            .WithMany(e => e.Utwory)
            .HasForeignKey(e => e.IdAlbum);

        builder.ToTable(nameof(Utwor));
    }
}