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
    
    [HttpGet("{id:int}")]
    public IActionResult GetAnimals(int id)
    {
        var animal = _animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
            return NotFound("Animal with id " + id + " was not found");
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        _animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var animalToEdit = _animals.FirstOrDefault(a => a.Id == id);
        if (animalToEdit == null)
            return NotFound("Animal with id " + id + " was not found");
        animalToEdit.Update(animal);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animalToDelete = _animals.FirstOrDefault(a => a.Id == id);
        if (animalToDelete == null)
            return NotFound("Animal with id " + id + " was not found");
        _animals.Remove(animalToDelete);
        return NoContent();
    }
}