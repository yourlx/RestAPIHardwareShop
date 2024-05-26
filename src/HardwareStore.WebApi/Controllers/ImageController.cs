using HardwareStore.WebApi.Data;
using HardwareStore.WebApi.DTO;
using HardwareStore.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HardwareStore.WebApi.Controllers;

// 1) todo: application is dying when image is big x_x (upload and update)
// 2) todo: not downloading image when requested ;( (by id, by product id)
[ApiController]
[Route("api/v1/images")]
public class ImageController : ControllerBase
{
    private readonly IImageService _imageService;

    public ImageController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromQuery] Guid productId, [FromBody] ImageDto imageDto)
    {
        try
        {
            var id = await _imageService.CreateAsync(productId, imageDto.Content);

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

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] ImageDto imageDto)
    {
        try
        {
            await _imageService.UpdateAsync(id, imageDto.Content);

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

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        try
        {
            await _imageService.DeleteAsync(id);

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

    [HttpGet("byProductId/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(byte[]))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByProductIdAsync([FromRoute] Guid id)
    {
        try
        {
            await _imageService.GetByProductIdAsync(id);

            return Ok();
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

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileContentResult))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        try
        {
            var image = await _imageService.GetAsync(id);

            var file = new FileContentResult(image, "application/octet-stream");
            file.FileDownloadName = "test.png";
            
            return Ok(file);
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