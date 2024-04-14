using Microsoft.AspNetCore.Mvc;
using REST_API.Models;

namespace REST_API.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private static readonly List<Animal> _animals =
    [
        new Animal("Fiona", AnimalCategories.Cat, 3.1, "Blue"),
        new Animal("Buba", AnimalCategories.Dog, 10.4, "Black")
    ];

    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }
}