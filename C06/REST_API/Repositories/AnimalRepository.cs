using System.Data.SqlClient;
using REST_API.Models;

namespace REST_API.Repositories;

public class AnimalRepository(IConfiguration configuration) : IAnimalsRepository
{
    private IConfiguration _configuration = configuration;

    public IEnumerable<Animal> GetAnimals()
    {
        using var sqlConnection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        using var sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandText = "SELECT * FROM Animal ORDER BY Name ASC";
        
        sqlConnection.Open();
        var dataReader = sqlCommand.ExecuteReader();
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
        using var sqlConnection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        using var sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandText = "INSERT INTO Animal (Name, Description, Category, Area) VALUES (@Name, @Description, @Category, @Area)";
        sqlCommand.Parameters.AddWithValue("@Name", animal.Name);
        sqlCommand.Parameters.AddWithValue("@Description", animal.Description);
        sqlCommand.Parameters.AddWithValue("@Category", animal.Category);
        sqlCommand.Parameters.AddWithValue("@Area", animal.Area);
        
        sqlConnection.Open();
        return sqlCommand.ExecuteNonQuery();
    }

    public int UpdateAnimal(Animal animal)
    {
        using var sqlConnection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        using var sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandText = "UPDATE Animal SET Name=@Name, Description=@Description, Category=@Category, Area=@Area WHERE IdAnimal = @IdAnimal";
        sqlCommand.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        sqlCommand.Parameters.AddWithValue("@Name", animal.Name);
        sqlCommand.Parameters.AddWithValue("@Description", animal.Description);
        sqlCommand.Parameters.AddWithValue("@Category", animal.Category);
        sqlCommand.Parameters.AddWithValue("@Area", animal.Name);
        
        sqlConnection.Open();
        return sqlCommand.ExecuteNonQuery();
        
    }

    public int DeleteAnimal(int idAnimal)
    {
        throw new NotImplementedException();
    }
}
