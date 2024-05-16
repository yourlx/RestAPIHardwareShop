using Microsoft.AspNetCore.Mvc;

namespace HardwareStore.WebApi.Controllers;

[ApiController]
[Route("api/v1/suppliers")]
public class SupplierController : ControllerBase
{
    public SupplierController()
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync()
    {
        // input: json of supplier
        return Ok();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateAddressAsync()
    {
        // input: id, address json
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        // input: id
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        // input: id
        return Ok();
    }
}