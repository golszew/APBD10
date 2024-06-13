using APBD10.Data;
using APBD10.Models;
using APBD10.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Services;

public class PatientService : IPatientService
{
    private readonly ApplicationContext _context;

    public PatientService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<bool> DoesPatientExist(int idPatient)
    {
        return await _context.Patients.AnyAsync(e => e.IdPatient == idPatient);
    }

    public async Task<PatientDto> GetPatientDetails(int idPatient)
    {
        // if (!await DoesPatientExist(idPatient))
        //     throw new InvalidOperationException($"Patient with id - {idPatient} doesn't exist");
        
        Patient patient = await  _context.Patients.Include(e => e.Prescriptions)
            .ThenInclude(e => e.Doctor)
            .Include(e => e.Prescriptions)
            .ThenInclude(e => e.PrescriptionMedicaments)
            .ThenInclude(e => e.Medicament)
            .SingleOrDefaultAsync(e => e.IdPatient == idPatient);
        return new PatientDto()
        {
            IdPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            BirthDate = patient.Date,
            Prescriptions = patient.Prescriptions
                .OrderBy(e => e.DueDate)
                .Select(e => new PrescriptionDto()
                {
                    IdPrescription = e.IdPrescription,
                    Date = e.Date,
                    DueDate = e.DueDate,
                    Doctor = new Doctor()
                    {
                        IdDoctor = e.IdDoctor,
                        FirstName = e.Doctor.FirstName,
                        LastName = e.Doctor.LastName
                    },
                    Medicaments = e.PrescriptionMedicaments.Select(pm => new MedicamentDto()
                    {
                        Id = pm.Medicament.IdMedicament,
                        Description = pm.Medicament.Description,
                        Dose = pm.Dose,
                    }).ToList()

                }).ToList()
        };
    }
}