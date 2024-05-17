using HardwareStore.WebApi.Data;
using HardwareStore.WebApi.DTO;
using HardwareStore.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HardwareStore.WebApi.Controllers;

[ApiController]
[Route("api/v1/clients")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;
    
    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] ClientDto client)
    {
        try
        {
            await _clientService.CreateAsync(client);
            
            return Ok();
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        try
        {
            await _clientService.DeleteAsync(id);

            return Ok();
        }
        catch (ClientNotFoundException exception)
        {
            return BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }

    [HttpGet("{name}/{surname}")]
    public async Task<IActionResult> GetByFullNameAsync([FromRoute] string name, [FromRoute] string surname)
    {
        try
        {
            var result = await _clientService.GetByFullNameAsync(name, surname);
            
            return Ok(result);
        }
        catch (ClientNotFoundException exception)
        {
            return BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] int? limit, [FromQuery] int? offset)
    {
        try
        {
            var result = await _clientService.GetAllAsync(limit, offset);
            
            return Ok(result);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAddressAsync([FromRoute] Guid id, [FromBody] AddressDto newAddress)
    {
        try
        {
            await _clientService.UpdateAddressAsync(id, newAddress);
            
            return Ok();
        }
        catch (ClientNotFoundException exception)
        {
            return BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }
}