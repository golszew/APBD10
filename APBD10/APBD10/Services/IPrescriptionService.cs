using APBD10.Models;

namespace APBD10.Services;

public interface IPrescriptionService
{
     Task AddPrescription(Prescription prescription);
     

}