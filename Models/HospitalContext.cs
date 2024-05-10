using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Models;

public class HospitalContext : DbContext
{
    public HospitalContext(DbContextOptions<HospitalContext> options)
        : base(options)
    {
    }

    public DbSet<Hospital> Hospitals{ get; set; } = null!;
}