using CODE_FIRST.Entities;
using Microsoft.EntityFrameworkCore;

namespace CODE_FIRST.Context;

public class ApdbContext : DbContext
{
    public ApdbContext() {}

    public ApdbContext(DbContextOptions<ApdbContext> options) : base(options) {}

    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Prescription_Medicament> PrescriptionMedicaments { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApdbContext).Assembly); 
    }
}