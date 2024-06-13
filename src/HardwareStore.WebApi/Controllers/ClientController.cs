using HardwareStore.WebApi.Data;
using HardwareStore.WebApi.DTO;
using HardwareStore.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HardwareStore.WebApi.Controllers;

/// <summary>
/// Clients API.
/// </summary>
/// <param name="clientService"></param>
[ApiController]
[Route("api/v1/clients")]
[Produces("application/json")]
public class ClientController(IClientService clientService) : ControllerBase
{
    /// <summary>
    /// Create a new client.
    /// </summary>
    /// <param name="createClientDto">Client data.</param>
    /// <returns>The created client.</returns>
    /// <response code="200">OK.</response>
    /// <response code="400">Bad Request. Input data invalid.</response>
    /// <response code="500">Interval Server Error.</response>
    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClientDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateClientDto createClientDto)
    {
        try
        {
            var clientDto = await clientService.CreateAsync(createClientDto);

            return Ok(clientDto);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }

    /// <summary>
    /// Delete a client by ID.
    /// </summary>
    /// <param name="id">Client ID.</param>
    /// <returns></returns>
    /// <response code="200">OK.</response>
    /// <response code="404">Not found.</response>
    /// <response code="500">Interval Server Error.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        try
        {
            await clientService.DeleteAsync(id);

            return Ok();
        }
        catch (ClientNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }

    /// <summary>
    /// Get clients by full name.
    /// </summary>
    /// <param name="name">Client's name.</param>
    /// <param name="surname">Client's surname.</param>
    /// <returns>Clients matching the provided name and surname.</returns>
    /// <response code="200">OK.</response>
    /// <response code="400">Bad request. Input data invalid.</response>
    /// <response code="500">Interval Server Error.</response>
    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClientDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByFullNameAsync([FromQuery] string name, [FromQuery] string surname)
    {
        try
        {
            var clientDtos = await clientService.GetByFullNameAsync(name, surname);

            return Ok(clientDtos);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }

    /// <summary>
    /// Get all clients.
    /// </summary>
    /// <param name="limit">Maximum number of clients to retrieve.</param>
    /// <param name="offset">Number of clients to skip.</param>
    /// <returns>All clients.</returns>
    /// <response code="200">OK.</response>
    /// <response code="500">Interval Server Error.</response>
    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ClientDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllAsync([FromQuery] int? limit, [FromQuery] int? offset)
    {
        try
        {
            var clientDtos = await clientService.GetAllAsync(limit, offset);

            return Ok(clientDtos);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }

    /// <summary>
    /// Update client address.
    /// </summary>
    /// <param name="id">Client ID.</param>
    /// <param name="addressDto">New address data.</param>
    /// <response code="200">OK.</response>
    /// <response code="400">Bad request. Input data invalid.</response>
    /// <response code="404">Not found.</response>
    /// <response code="500">Interval Server Error.</response>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateAddressAsync([FromRoute] Guid id, [FromBody] AddressDto addressDto)
    {
        try
        {
            await clientService.UpdateAddressAsync(id, addressDto);

            return Ok();
        }
        catch (ClientNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }
}