using Microsoft.AspNetCore.Mvc;
using REST_API.Models;
using REST_API.Services;

namespace REST_API.Controllers;

[Route("api/warehouse")]
[ApiController]
public class WarehouseController(IWarehouseService service) : ControllerBase
{
    [HttpPut]
    public IActionResult Edit([FromBody] Warehouse warehouse)
    {
        return Ok(service.InsertIntoProductWarehouse(warehouse));
    }
}