using HardwareStore.WebApi.Data;
using HardwareStore.WebApi.DTO;
using HardwareStore.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HardwareStore.WebApi.Controllers;

/// <summary>
/// Suppliers API.
/// </summary>
/// <param name="supplierService"></param>
[ApiController]
[Route("api/v1/suppliers")]
[Produces("application/json")]
public class SupplierController(ISupplierService supplierService) : ControllerBase
{
    /// <summary>
    /// Create a new supplier.
    /// </summary>
    /// <param name="createSupplierDto">Supplier data.</param>
    /// <returns>The created supplier.</returns>
    /// <response code="200">OK.</response>
    /// <response code="400">Bad request. Input data invalid.</response>
    /// <response code="500">Interval Server Error.</response>
    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SupplierDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateSupplierDto createSupplierDto)
    {
        try
        {
            var supplierDto = await supplierService.CreateAsync(createSupplierDto);

            return Ok(supplierDto);
        }
        catch (PhoneNumberFormatException exception)
        {
            return BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }

    /// <summary>
    /// Update supplier address.
    /// </summary>
    /// <param name="id">Supplier ID.</param>
    /// <param name="addressDto">New address data.</param>
    /// <returns></returns>
    /// <response code="200">OK.</response>
    /// <response code="400">Bad request. Input data invalid.</response>
    /// <response code="404">Not found.</response>
    /// <response code="500">Interval Server Error.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateAddressAsync([FromRoute] Guid id, [FromBody] AddressDto addressDto)
    {
        try
        {
            await supplierService.UpdateAddressAsync(id, addressDto);

            return Ok();
        }
        catch (SupplierNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }

    /// <summary>
    /// Delete a supplier by ID.
    /// </summary>
    /// <param name="id">Supplier ID.</param>
    /// <returns></returns>
    /// <response code="200">OK.</response>
    /// <response code="404">Not found.</response>
    /// <response code="500">Interval Server Error.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        try
        {
            await supplierService.DeleteAsync(id);

            return Ok();
        }
        catch (SupplierNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }

    /// <summary>
    /// Get all suppliers.
    /// </summary>
    /// <returns>All suppliers.</returns>
    /// <response code="200">OK.</response>
    /// <response code="500">Interval Server Error.</response>
    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SupplierDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var supplierDtos = await supplierService.GetAllAsync();

            return Ok(supplierDtos);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }

    /// <summary>
    /// Get a supplier by ID.
    /// </summary>
    /// <param name="id">Supplier ID.</param>
    /// <returns>The requested supplier.</returns>
    /// <response code="200">OK.</response>
    /// <response code="404">Not found.</response>
    /// <response code="500">Interval Server Error.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SupplierDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        try
        {
            var supplierDto = await supplierService.GetAsync(id);

            return Ok(supplierDto);
        }
        catch (SupplierNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }
}