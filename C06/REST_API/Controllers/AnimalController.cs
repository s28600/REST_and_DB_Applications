using Microsoft.AspNetCore.Mvc;
using REST_API.Repositories;

namespace REST_API.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalController(IAnimalsRepository animalsRepository) : ControllerBase
{
    private IAnimalsRepository _animalsRepository = animalsRepository;

    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animalsRepository.GetAnimals());
    }
}