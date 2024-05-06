using REST_API.Models;

namespace REST_API.Services;

public class WarehouseService(IConfiguration configuration) : IWarehouseService
{
    private IConfiguration _configuration = configuration;
    
    public void UpdateWarehouse(Warehouse warehouse)
    {
        throw new NotImplementedException();
    }
}