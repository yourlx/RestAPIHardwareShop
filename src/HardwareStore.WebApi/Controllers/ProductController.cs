using Microsoft.AspNetCore.Mvc;

namespace HardwareStore.WebApi.Controllers;

[ApiController]
[Route("api/v1/products")]
public class ProductController : ControllerBase
{
    public ProductController()
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync()
    {
        // input: json of product
        return Ok();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateQuantityAsync()
    {
        // input: id, quantity (reduce amount, NOT after reduce)
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        // input: id
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        // input: id
        return Ok();
    }
}