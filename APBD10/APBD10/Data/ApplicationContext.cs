using APBD10.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Data;

public class ApplicationContext : DbContext
{
    protected ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
        {
            new Doctor()
            {
                IdDoctor = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "kowal@kowal.pl"
            },
            new Doctor()
            {
                IdDoctor = 2,
                FirstName = "Wojciech",
                LastName = "Pietrucha",
                Email = "pietrucha@pietrucha.pl"
            }
        });

        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>()
        {
            new Medicament()
            {
                IdMedicament = 1,
                Name = "Apap",
                Description = "Na bol glowy",
                Type = "doustny"
            },
            new Medicament()
            {
                IdMedicament = 2,
                Name = "Paracetamol",
                Description = "Na bol goraczke",
                Type = "doustny"
            }
        });

        modelBuilder.Entity<Patient>().HasData(new List<Patient>()
        {
            new Patient()
            {   
                IdPatient = 1,
                FirstName = "Pawel",
                LastName = "Molenda",
                Date = DateTime.ParseExact("24-05-1965", "dd-MM-yyyy", null)
            },
            new Patient()
            {
                IdPatient = 2,
                FirstName = "Michal",
                LastName = "Grzeda",
                Date = DateTime.ParseExact("21-03-1968", "dd-MM-yyyy", null)
            }
        });
        
        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>()
        {
         
            new Prescription()
            {
                IdPrescription = 1,
                IdDoctor = 1,
                IdPatient = 1,
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddDays(10)
            },
            new Prescription()
            {
                IdPrescription = 2,
                IdDoctor = 2,
                IdPatient = 2,
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddDays(20)
            }
        });

        modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>()
        {
            new PrescriptionMedicament()
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Details = "szybko",

            },
            new PrescriptionMedicament()
            {
                IdMedicament = 2,
                IdPrescription = 2,
                Details = "wolno",
                Dose = 10.5
            }
        });
    }
}