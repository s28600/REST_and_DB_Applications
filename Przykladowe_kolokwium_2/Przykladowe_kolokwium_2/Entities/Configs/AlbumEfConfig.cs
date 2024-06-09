using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Przykladowe_kolokwium_2.Entities.Configs;

public class AlbumEfConfig : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.HasKey(e => e.IdAlbum);
        builder.Property(e => e.IdAlbum).UseIdentityColumn();
        builder.Property(e => e.NazwaAlbumu).IsRequired().HasMaxLength(30);
        builder.Property(e => e.DataWydania).IsRequired();

        builder.HasOne(e => e.Wytwornia)
            .WithMany(e => e.Albums)
            .HasConstraintName("Wytwornia_Album")
            .HasForeignKey(e => e.IdWytwornia)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(nameof(Album));
    }
}