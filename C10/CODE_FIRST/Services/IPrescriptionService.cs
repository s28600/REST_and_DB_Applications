using CODE_FIRST.RequestModels;

namespace CODE_FIRST.Services;

public interface IPrescriptionService
{
    public Task<bool> AddPrescription(PrescriptionRequest prescriptionRequest);
}