using System.Data.SqlClient;
using REST_API.Models;

namespace REST_API.Repositories;

public class AnimalRepository(IConfiguration configuration) : IAnimalsRepository
{
    private IConfiguration _configuration = configuration;

    public IEnumerable<Animal> GetAnimals()
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM Animal ORDER BY Name ASC";
        
        connection.Open();
        var dataReader = command.ExecuteReader();
        var animals = new List<Animal>();
        while (dataReader.Read())
        {
            var animal = new Animal(
                idAnimal:(int)dataReader["IdAnimal"],
                name:dataReader["Name"].ToString(), 
                description:dataReader["Description"].ToString(),
                category:dataReader["Category"].ToString(),
                area:dataReader["Area"].ToString()
                );
            animals.Add(animal);
        }

        return animals;
    }

    public int CreateAnimal(Animal animal)
    {
        throw new NotImplementedException();
    }

    public int UpdateAnimal(Animal animal)
    {
        throw new NotImplementedException();
    }

    public int DeleteAnimal(int idAnimal)
    {
        throw new NotImplementedException();
    }
}
