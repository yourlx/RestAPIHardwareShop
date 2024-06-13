using HardwareStore.WebApi.Data;
using HardwareStore.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HardwareStore.WebApi.Controllers;

/// <summary>
/// Images API.
/// </summary>
/// <param name="imageService"></param>
[ApiController]
[Route("api/v1/images")]
[Produces("application/json")]
public class ImageController(IImageService imageService) : ControllerBase
{
    /// <summary>
    /// Add image to existing product.
    /// </summary>
    /// <param name="productId">Product ID.</param>
    /// <param name="image">Image content.</param>
    /// <returns>Created image ID.</returns>
    /// <response code="200">OK.</response>
    /// <response code="400">Bad request. Input data invalid.</response>
    /// <response code="404">Not found.</response>
    /// <response code="409">Conflict. Product already have image.</response>
    /// <response code="500">Interval Server Error.</response>
    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromQuery] Guid productId, IFormFile image)
    {
        try
        {
            // todo: leave conversion here or move to service?
            using var memoryStream = new MemoryStream();
            await image.CopyToAsync(memoryStream);

            var id = await imageService.CreateAsync(productId, memoryStream.ToArray());

            return Ok(id);
        }
        catch (ProductNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (ProductHasImageException exception)
        {
            return Conflict(exception.Message);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }

    /// <summary>
    /// Update existing image content.
    /// </summary>
    /// <param name="id">Image ID.</param>
    /// <param name="image">New image content.</param>
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
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, IFormFile image)
    {
        try
        {
            // todo: leave conversion here or move to service?
            using var memoryStream = new MemoryStream();
            await image.CopyToAsync(memoryStream);

            await imageService.UpdateAsync(id, memoryStream.ToArray());

            return Ok();
        }
        catch (ImageNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }

    /// <summary>
    /// Delete existing image.
    /// Also removes image relation from product.
    /// </summary>
    /// <param name="id">Image ID.</param>
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
            await imageService.DeleteAsync(id);

            return Ok();
        }
        catch (ImageNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }

    /// <summary>
    /// Get image content by product ID.
    /// </summary>
    /// <param name="id">Product ID.</param>
    /// <returns>Image content.</returns>
    /// <response code="200">OK.</response>
    /// <response code="404">Not found.</response>
    /// <response code="500">Interval Server Error.</response>
    [HttpGet("byProduct/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileContentResult))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByProductIdAsync([FromRoute] Guid id)
    {
        try
        {
            var image = await imageService.GetByProductIdAsync(id);

            return File(image.Content, "application/octet-stream", "file.png");
        }
        catch (ImageNotFoundException exception)
        {
            return NotFound(exception.Message);
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
    /// Get image content by ID.
    /// </summary>
    /// <param name="id">Image ID.</param>
    /// <returns>Image content.</returns>
    /// <response code="200">OK.</response>
    /// <response code="404">Not found.</response>
    /// <response code="500">Interval Server Error.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileContentResult))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        try
        {
            var image = await imageService.GetAsync(id);

            return File(image.Content, "application/octet-stream", "file.png");
        }
        catch (ImageNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }
}