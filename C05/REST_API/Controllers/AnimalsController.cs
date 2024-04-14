using Microsoft.AspNetCore.Mvc;
using REST_API.Databases;
using REST_API.Models;

namespace REST_API.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(Animals._animals);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetAnimals(int id)
    {
        var animal = Animals._animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
            return NotFound("Animal with id " + id + " was not found");
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        Animals._animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var animalToEdit = Animals._animals.FirstOrDefault(a => a.Id == id);
        if (animalToEdit == null)
            return NotFound("Animal with id " + id + " was not found");
        animalToEdit.Update(animal);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animalToDelete = Animals._animals.FirstOrDefault(a => a.Id == id);
        if (animalToDelete == null)
            return NotFound("Animal with id " + id + " was not found");
        Animals._animals.Remove(animalToDelete);
        return NoContent();
    }
}