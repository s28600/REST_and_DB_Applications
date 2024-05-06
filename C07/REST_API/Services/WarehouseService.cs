using System.Data.SqlClient;
using REST_API.Models;

namespace REST_API.Services;

public class WarehouseService(IConfiguration configuration) : IWarehouseService
{
    private IConfiguration _configuration = configuration;
    
    public void UpdateWarehouse(Warehouse warehouse)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        if (!ProductExists(connection, warehouse.IdProduct))
            throw new Exception("Product with provided id does not exist");
        if (!WarehouseExists(connection, warehouse.IdWarehouse))
            throw new Exception("Warehouse with provided id does not exist");
        if (warehouse.Amount <= 0 )
            throw new Exception("Amount should be greater than 0");
    }
    
    private bool ProductExists(SqlConnection connection, int id)
    {
        using var command = new SqlCommand("SELECT COUNT(1) FROM Product WHERE IdProduct = @Id", connection);
        command.Parameters.AddWithValue("@id", id);
        return (int)command.ExecuteScalar() > 0;
    }

    private bool WarehouseExists(SqlConnection connection, int id)
    {
        using var command = new SqlCommand("SELECT COUNT(1) FROM Warehouse WHERE IdWarehouse = @Id", connection);
        command.Parameters.AddWithValue("@id", id);
        return (int)command.ExecuteScalar() > 0;
    }
}