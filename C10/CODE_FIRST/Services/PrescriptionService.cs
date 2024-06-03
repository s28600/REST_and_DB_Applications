using CODE_FIRST.Context;

namespace CODE_FIRST.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly MedDbContext _dbMedDbContext;

    public PrescriptionService(MedDbContext dbMedDbContext)
    {
        _dbMedDbContext = dbMedDbContext;
    }
    
    public bool AddPrescription()
    {
        throw new NotImplementedException();
    }
}