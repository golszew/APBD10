namespace APBD10.Services;

public interface IMedicamentService
{
    Task<bool> DoesMedicamentExist(int idMedicament);
}