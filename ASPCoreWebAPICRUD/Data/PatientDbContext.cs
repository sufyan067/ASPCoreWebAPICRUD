using Microsoft.EntityFrameworkCore;
using PatientManagement.Entities;
using PatientManagement.EntityConfiguration;

namespace PatientManagement.Data;
public class PatientDbContext : DbContext
{
    public PatientDbContext(DbContextOptions<PatientDbContext> options)
        : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
        //  modelBuilder.ApplyConfigurationsFromAssembly(typeof(PatientDbContext).Assembly);   // New way 

    }
}