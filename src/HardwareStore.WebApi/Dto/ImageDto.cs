namespace HardwareStore.WebApi.DTO;

/// <summary>
/// Image DTO.
/// </summary>
/// <param name="Id" example="3fa85f64-5717-4562-b3fc-2c963f66afa6">Image ID.</param>
/// <param name="Content">Image content in byte array format.</param>
public record ImageDto(Guid Id, byte[] Content);