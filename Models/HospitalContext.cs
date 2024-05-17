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

        modelBuilder.Entity<DoctorHospital>()
            .HasKey(dh => new {dh.DoctorId, dh.HospitalId});

        modelBuilder.Entity<DoctorHospital>()
            .HasOne(dh => dh.Doctor)
            .WithMany()
            .HasForeignKey(dh=>dh.DoctorId);

        modelBuilder.Entity<DoctorHospital>()
            .HasOne(dh => dh.Doctor)
            .WithMany()
            .HasForeignKey(dh=>dh.DoctorId);



    }
    public DbSet<Hospital> Hospitals { get; set; } = null!;
    public DbSet<Doctor> Doctors { get; set; } = null!;
    public DbSet <DoctorHospital> DoctorHospitals {get;set;}
}