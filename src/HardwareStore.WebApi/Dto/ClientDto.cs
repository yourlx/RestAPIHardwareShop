namespace HardwareStore.WebApi.DTO;

/// <summary>
/// Client DTO.
/// </summary>
/// <param name="Id" example="3fa85f64-5717-4562-b3fc-2c963f66afa6">Client ID.</param>
/// <param name="Name" example="John">Client name.</param>
/// <param name="Surname" example="Doe">Client surname.</param>
/// <param name="Birthday" example="2001-05-23">Client birthday.</param>
/// <param name="Gender" example="Male">Client gender.</param>
/// <param name="Address">Client address.</param>
public record ClientDto(Guid Id, string Name, string Surname, DateOnly Birthday, string Gender, AddressDto Address);