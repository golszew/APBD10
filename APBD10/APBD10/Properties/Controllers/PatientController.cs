using APBD10.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD10.Properties.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet("{idPatient}")]
    public async Task<IActionResult> GetPatientDetails(int idPatient)
    {
        try
        {
            return Ok(await _patientService.GetPatientDetails(idPatient));

        }
        catch (InvalidOperationException e)
        {
            return NotFound(new { message = e.Message });
        }
    }
}