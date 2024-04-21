using System.ComponentModel.DataAnnotations;
using System.Data;

namespace REST_API.Models;

public class Animal(int idAnimal, string name, string description, string category, string area)
{ 
    [Required]
    public int IdAnimal { get; set; } = idAnimal;

    public string Name { get; set; } = name;

    [Required]
    public string Description { get; set; } = description;

    public string Category { get; set; } = category;
    public string Area { get; set; } = area;
}