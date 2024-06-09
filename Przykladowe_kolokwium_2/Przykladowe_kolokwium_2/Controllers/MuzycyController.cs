using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Przykladowe_kolokwium_2.Services;

namespace Przykladowe_kolokwium_2.Controllers;

[Route("api/muzycy")]
[ApiController]
public class MuzycyController : ControllerBase
{
    private IMuzykService _muzykService;

    public MuzycyController(IMuzykService muzykService)
    {
        _muzykService = muzykService;
    }

    [HttpGet("{id:int}")]
    public IActionResult GetMuzyk(int id)
    {
        var muzyk = _muzykService.GetMuzyk(id);
        return Ok(muzyk);
    }
}