using REST_API.Databases;

namespace REST_API.Models;

public class Appointment
{
    public DateTime Date { get; set; }
    public Animal Animal { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }

    public Appointment(DateTime date, int id, string description, double price)
    {
        Date = date;
        var animal = Animals._animals.FirstOrDefault(a => a.Id==id);
        if (animal == null)
            throw new Exception("No animal with id " + id + ", cant create appointment");
        Animal = animal;
        Description = description;
        Price = price;
    }
}