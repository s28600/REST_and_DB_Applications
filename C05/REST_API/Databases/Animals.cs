using REST_API.Models;

namespace REST_API.Databases;

public class Animals
{
    public static readonly List<Animal> _animals =
    [
        new Animal("Fiona", AnimalCategories.Cat, 3.1, "Blue"),
        new Animal("Buba", AnimalCategories.Dog, 10.4, "Black")
    ];
}