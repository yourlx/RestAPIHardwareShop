using Microsoft.AspNetCore.Mvc;

namespace HardwareStore.WebApi.Controllers;

[ApiController]
[Route("api/v1/images")]
public class ImageController : ControllerBase
{
    public ImageController()
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync()
    {
        // input: byte[], productId
        return Ok();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateAsync()
    {
        // input: id, byte[]
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteByIdAsync(Guid id)
    {
        // input: id
        return Ok();
    }

    [HttpGet("byProductId/{productId}")]
    public async Task<IActionResult> GetByProductIdAsync(Guid productId)
    {
        // input: productId
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        // input: imageId
        return Ok();
    }
}