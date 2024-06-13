using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Models;

[Table("Prescription_Medicament")]
[PrimaryKey(nameof(IdMedicament), nameof(IdPrescription))]
public class PrescriptionMedicament
{
    public int IdMedicament { get; set; }
    public int IdPrescription { get; set; }
    public double Dose { get; set; }
    [MaxLength(100)]
    public string Details { get; set; }

    [ForeignKey(nameof(IdMedicament))]
    public Medicament Medicament { get; set; }
    
    [ForeignKey(nameof(IdPrescription))] 
    public Prescription Prescription { get; set; }
    
}