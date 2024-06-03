using CODE_FIRST.Context;
using CODE_FIRST.Entities;
using CODE_FIRST.RequestModels;

namespace CODE_FIRST.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly MedDbContext _medDbContext;

    public PrescriptionService(MedDbContext medDbContext)
    {
        _medDbContext = medDbContext;
    }
    
    public async Task<bool> AddPrescription(PrescriptionRequest request)
    {
        if (request.Medicaments.Count > 10 || request.DueDate < request.Date)
            return false;
        
        int[] medicamentIds = request.Medicaments.Select(m => m.IdMedicament).ToArray();
        List<Medicament> medicaments = _medDbContext.Medicaments.Where(m => medicamentIds.Contains(m.IdMedicament)).ToList();
        if (medicamentIds.Length != medicaments.Count)
            return false;
        
        Patient? patient = _medDbContext.Patients.FindAsync(request.Patient.IdPatient).Result;
        if (patient == null)
        {
            patient = new Patient()
            {
                FirstName = request.Patient.FirstName,
                LastName = request.Patient.LastName,
                BirthDate = request.Patient.BirthDate
            }; 
            await _medDbContext.Patients.AddAsync(patient);
        }
        
        var newPrescription = new Prescription()
        {
            Date = request.Date,
            DueDate = request.DueDate,
            Doctor = _medDbContext.Doctors.First(d => d.IdDoctor == 1),
            Patient = patient
        };

        newPrescription.PrescriptionMedicaments = medicaments.Select(medicament => new Prescription_Medicament()
            {
                Dose = 1,
                Details = "",
                IdMedicament = medicament.IdMedicament,
                IdPrescription = newPrescription.IdPrescription,
                Medicament = medicament,
                Prescription = newPrescription
            })
            .ToList();
        
        await _medDbContext.Prescriptions.AddAsync(newPrescription);
        await _medDbContext.SaveChangesAsync();
        return true;
    }
}