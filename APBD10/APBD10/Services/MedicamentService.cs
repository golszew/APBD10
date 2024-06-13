using APBD10.Data;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Services;

public class MedicamentService : IMedicamentService
{

    private readonly ApplicationContext _context;

    public MedicamentService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<bool> DoesMedicamentExist(int idMedicament)
    {
        return await _context.Medicaments.AnyAsync(e => e.IdMedicament == idMedicament);
    }
}