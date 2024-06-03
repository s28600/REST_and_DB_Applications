using CODE_FIRST.Entities;
using CODE_FIRST.RequestModels;
using CODE_FIRST.Services;
using Microsoft.AspNetCore.Mvc;

namespace CODE_FIRST.Controllers;

[Route("api/prescription")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private IPrescriptionService _service;
    
    public PrescriptionController(IPrescriptionService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public IActionResult AddPrescription(PrescriptionRequest prescriptionRequest)
    {
        return Ok();
    }
}