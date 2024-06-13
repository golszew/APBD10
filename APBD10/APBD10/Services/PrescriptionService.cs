using APBD10.Data;
using APBD10.Models;

namespace APBD10.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly ApplicationContext _context;
    private readonly IPatientService _patientService;
    private readonly IMedicamentService _medicamentService;

    public PrescriptionService(ApplicationContext context, IPatientService patientService, IMedicamentService medicamentService)
    {
        _context = context;
        _patientService = patientService;
        _medicamentService = medicamentService;
    }

    public async Task AddPrescription(Prescription prescription)
    {
        if (!await _patientService.DoesPatientExist(prescription.IdPatient))
        {
            await _context.AddAsync(prescription.Patient);
            await _context.SaveChangesAsync();
        }
        
        foreach (var pre in prescription.PrescriptionMedicaments)
        {
            if (!await _medicamentService.DoesMedicamentExist(pre.IdMedicament))
                throw new InvalidOperationException($"Medicament {pre.Medicament.Name} does not exist in DataBase");
        }
        
        if (prescription.PrescriptionMedicaments.Count > 10)
            throw new InvalidOperationException("Cannot add more than 10 medicaments!");

        if (prescription.DueDate < DateTime.Now)
            throw new InvalidOperationException("Prescription is outdated!");

        await _context.Prescriptions.AddAsync(prescription);
        await _context.SaveChangesAsync();

    }
}