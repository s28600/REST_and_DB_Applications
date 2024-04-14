namespace REST_API.Models;

public class Animal
{
    private static int _id = 0;
    public int Id { get; set; }
    public string Name { get; set; }
    public AnimalCategories Category { get; set; }
    public double Weight { get; set; }
    public string Color { get; set; }

    public Animal(string name, AnimalCategories category, double weight, string color)
    {
        Id = _id++;
        Name = name;
        Category = category;
        Weight = weight;
        Color = color;
    }
}