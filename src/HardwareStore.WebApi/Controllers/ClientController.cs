using Microsoft.AspNetCore.Mvc;

namespace HardwareStore.WebApi.Controllers;

[ApiController]
[Route("api/v1/clients")]
public class ClientController : ControllerBase
{
    public ClientController()
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync()
    {
        // input: json of client
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        // input: id
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetByFullNameAsync([FromQuery] string name, [FromQuery] string surname)
    {
        // input: name, surname
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int? limit, [FromQuery] int? offset)
    {
        // limit && offset, if empty return all
        return Ok();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateAddressAsync()
    {
        // input: id, address json
        return Ok();
    }
}