using CODE_FIRST.Models;
using Microsoft.EntityFrameworkCore;

namespace CODE_FIRST.Context;

public class ApdbContext : DbContext
{
    public ApdbContext()
    {
    }

    public ApdbContext(DbContextOptions<ApdbContext> options) : base(options)
    {
    }

    public DbSet<Medicament> Medicaments { get; set; }
}