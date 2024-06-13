using HardwareStore.WebApi.Data;
using HardwareStore.WebApi.DTO;
using HardwareStore.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HardwareStore.WebApi.Controllers;

/// <summary>
/// Products API.
/// </summary>
/// <param name="productService"></param>
[ApiController]
[Route("api/v1/products")]
[Produces("application/json")]
public class ProductController(IProductService productService) : ControllerBase
{
    /// <summary>
    /// Create a new product.
    /// </summary>
    /// <param name="createProductDto">Product data.</param>
    /// <returns>The created product.</returns>
    /// <response code="200">OK.</response>
    /// <response code="400">Bad request. Input data invalid.</response>
    /// <response code="404">Not found.</response>
    /// <response code="500">Interval Server Error.</response>
    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateProductDto createProductDto)
    {
        try
        {
            var productDto = await productService.CreateAsync(createProductDto);

            return Ok(productDto);
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
    /// Update product quantity.
    /// </summary>
    /// <param name="id">Product ID.</param>
    /// <param name="reduceQuantity">Quantity to reduce.</param>
    /// <returns></returns>
    /// <response code="200">OK.</response>
    /// <response code="400">Bad request. Input data invalid.</response>
    /// <response code="404">Not found.</response>
    /// <response code="409">Conflict. Too much quantity to reduce.</response>
    /// <response code="500">Interval Server Error.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateQuantityAsync([FromRoute] Guid id, [FromQuery] int reduceQuantity)
    {
        try
        {
            await productService.UpdateQuantityAsync(id, reduceQuantity);

            return Ok();
        }
        catch (ProductNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (ProductNotEnoughException exception)
        {
            return Conflict(exception.Message);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }

    /// <summary>
    /// Get a product by ID.
    /// </summary>
    /// <param name="id">Product ID.</param>
    /// <returns>The requested product.</returns>
    /// <response code="200">OK.</response>
    /// <response code="404">Not found.</response>
    /// <response code="500">Interval Server Error.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        try
        {
            var productDto = await productService.GetAsync(id);

            return Ok(productDto);
        }
        catch (ProductNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }

    /// <summary>
    /// Get all products.
    /// </summary>
    /// <returns>All products.</returns>
    /// <response code="200">OK.</response>
    /// <response code="500">Interval Server Error.</response>
    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var productDtos = await productService.GetAllAsync();

            return Ok(productDtos);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }

    /// <summary>
    /// Delete a product by ID.
    /// </summary>
    /// <param name="id">Product ID.</param>
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
            await productService.DeleteAsync(id);

            return Ok();
        }
        catch (ProductNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }
}