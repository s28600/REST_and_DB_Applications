using Microsoft.AspNetCore.Mvc;
using REST_API.Databases;
using REST_API.Models;

namespace REST_API.Controllers;

[Route("api/appointments")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    [HttpGet("{id:int}")]
    public IActionResult GetAppointmentsForId(int id)
    {
        List<Appointment> appointments = Appointments.GetById(id);
        if (appointments.Count == 0)
        {
            return NotFound("No appointments for animal with id " + id + " were found");
        }

        return Ok(appointments);
    }
}