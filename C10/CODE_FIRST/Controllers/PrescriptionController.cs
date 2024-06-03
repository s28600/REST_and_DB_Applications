using CODE_FIRST.Entities;
using CODE_FIRST.RequestModels;
using CODE_FIRST.Services;
using Microsoft.AspNetCore.Mvc;

namespace CODE_FIRST.Controllers;

[Route("api/prescription")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private IPrescriptionService _prescriptionService;
    
    public PrescriptionController(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }
    
    [HttpPost]
    public IActionResult AddPrescription(PrescriptionRequest prescriptionRequest)
    {
        if (!_prescriptionService.AddPrescription(prescriptionRequest).Result)
            return StatusCode(400);
        return Ok();
    }
}