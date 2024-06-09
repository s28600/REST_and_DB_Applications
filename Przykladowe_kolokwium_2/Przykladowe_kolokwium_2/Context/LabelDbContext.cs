using Microsoft.EntityFrameworkCore;
using Przykladowe_kolokwium_2.Entities;

namespace Przykladowe_kolokwium_2.Context;

public class LabelDbContext : DbContext
{
    protected LabelDbContext() {}

    public LabelDbContext(DbContextOptions options) : base(options) {}

    public DbSet<Wytwornia> Wytwornie { get; set; }
    public DbSet<Album> Albumy { get; set; }
    public DbSet<Utwor> Utwory { get; set; }
    public DbSet<Muzyk> Muzycy { get; set; }
    public DbSet<WykonawcaUtworu> Wykonawcy { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LabelDbContext).Assembly); 
    }
}