using Hospital.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data;

public class HospitalContext(DbContextOptions<HospitalContext> options) : DbContext(options)
{
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<Doctor> Doctors => Set<Doctor>();
    public DbSet<Patient> Patients => Set<Patient>();
    
    public PatientBlank PatientBlanks { get; } = new PatientBlank();
    public Speciality Specialities { get; } = new Speciality();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(opt =>
        {
            opt.HasKey(x => x.AppointmentId);

            opt.HasOne(x => x.Patient)
                .WithMany(x => x.Appointments);

            opt.HasOne(x => x.Doctor)
                .WithMany(x => x.Appointments);
        });

        modelBuilder.Entity<Doctor>(opt =>
        {
            opt.HasKey(x => x.DoctorId);

            opt.HasOne(x => x.Speciality)
                .WithMany();
        });

        modelBuilder.Entity<Patient>(opt =>
        {
            opt.HasKey(x => x.PatientId);
        });
        
        modelBuilder.Entity<PatientBlank>(opt =>
        {
            opt.HasKey(x => x.PatientBlankId);
            
            opt.HasOne(x => x.Patient)
                .WithOne(x => x.PatientBlank)
                .HasForeignKey<PatientBlank>(x => x.PatientId);
        });
        
        modelBuilder.Entity<Speciality>(opt =>
        {
            opt.HasKey(x => x.SpecialityId);
        });
    }
}
