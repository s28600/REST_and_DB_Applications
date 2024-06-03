using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CODE_FIRST.Entities;

public class Prescription
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    
    public virtual ICollection<Prescription_Medicament> PrescriptionMedicaments { get; set; }
}