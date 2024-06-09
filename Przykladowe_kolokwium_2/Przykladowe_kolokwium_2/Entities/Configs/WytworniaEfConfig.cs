using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Przykladowe_kolokwium_2.Entities.Configs;

public class WytworniaEfConfig : IEntityTypeConfiguration<Wytwornia>
{
    public void Configure(EntityTypeBuilder<Wytwornia> builder)
    {
        builder.HasKey(e => e.IdWytwornia);
        builder.Property(e => e.IdWytwornia).UseIdentityColumn();
        builder.Property(e => e.Nazwa).IsRequired().HasMaxLength(50);

        builder.ToTable(nameof(Wytwornia));
    }
}