using Microsoft.EntityFrameworkCore;

namespace zad10.Data;

public class myContext : DbContext
{
    protected myContext()
    {
        
    }
    
    public myContext(DbContextOptions<myContext> options) : base(options)
    {
        
    }
    
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Perscription> Perscriptions { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Perscription_Medicament> Perscription_Medicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
        {
            new Doctor
            {
                IdDoctor = 1,
                firstName = "jan",
                lastName = "kowalski",
                email = "asd@gmail.com"
            },
            new Doctor
            {
                IdDoctor = 2,
                firstName = "stefan",
                lastName = "nowak",
                email = "zxc@gmail.com"
            },
        });

        modelBuilder.Entity<Patient>().HasData(new List<Patient>
        {
            new Patient
            {
                IdPatient = 1,
                firstName = "jan",
                lastName = "kowalski",
                BirthDate = new DateTime(1990, 3, 1, 13, 25, 13)
            },
            new Patient
            {
                IdPatient = 2,
                firstName = "stefan",
                lastName = "nowak",
                BirthDate = new DateTime(1995, 4, 12, 13, 25, 13)
            },
        });

        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
        {
            new Medicament
            {
                IdMedicament = 1,
                Name = "alpra",
                Description = "mocna",
                Type = "benzo"
            },
            new Medicament
            {
                IdMedicament = 2,
                Name = "oksy",
                Description = "bardzo mocna",
                Type = "opio"
            }
        });

        modelBuilder.Entity<Perscription>().HasData(new List<Perscription>
        {
            new Perscription
            {
                IdPerscription = 1,
                Date = new DateTime(2024, 4, 12, 13, 25, 13),
                DueDate = new DateTime(2024, 6, 12, 16, 25, 13),
                IdPatient = 1,
                IdDoctor = 1
            }
        });

        modelBuilder.Entity<Perscription_Medicament>().HasData(new List<Perscription_Medicament>
        {
            new Perscription_Medicament
            {
                IdMedicament = 2,
                IdPerscription = 1,
                dose = 12,
                Details = "zaza"
            }
        });
    }
}