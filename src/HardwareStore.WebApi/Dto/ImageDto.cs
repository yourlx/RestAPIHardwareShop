namespace HardwareStore.WebApi.DTO;

/// <summary>
/// Image DTO.
/// </summary>
/// <param name="Id">Image ID.</param>
/// <param name="Content">Image content in byte array format.</param>
public record ImageDto(Guid Id, byte[] Content);