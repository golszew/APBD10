using APBD10.Models;
using APBD10.Models.DTOs;

namespace APBD10.Services;

public interface IPatientService
{
    Task<bool> DoesPatientExist(int idPatient);
    Task<PatientDto> GetPatientDetails(int idPatient);
}