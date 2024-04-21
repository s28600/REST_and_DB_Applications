using Microsoft.AspNetCore.Mvc;
using REST_API.Models;
using REST_API.Repositories;

namespace REST_API.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalController(IAnimalsRepository animalsRepository) : ControllerBase
{
    private IAnimalsRepository _animalsRepository = animalsRepository;

    [HttpGet]
    public IActionResult GetAnimals(string orderBy = "Name")
    {
        return Ok(_animalsRepository.GetAnimals(orderBy));
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        var affectedCount = _animalsRepository.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var affectedCount = _animalsRepository.UpdateAnimal(animal);
        return StatusCode(StatusCodes.Status204NoContent);
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var affectedCount = _animalsRepository.DeleteAnimal(id);
        return StatusCode(StatusCodes.Status204NoContent);
    }
}