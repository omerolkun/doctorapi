using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Models;

public class HospitalContext : DbContext
{
    public HospitalContext(DbContextOptions<HospitalContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>()
            .HasAlternateKey(i => i.TCKN);
    }
    public DbSet<Hospital> Hospitals { get; set; } = null!;
    public DbSet<Doctor> Doctors { get; set; } = null!;
    public DbSet <DoctorHospital> DoctorHospitals {get;set;}
}