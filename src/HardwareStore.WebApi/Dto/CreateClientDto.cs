namespace HardwareStore.WebApi.DTO;

/// <summary>
/// Create Client DTO.
/// </summary>
/// <param name="Name" example="John">Client name.</param>
/// <param name="Surname" example="Doe">Client surname.</param>
/// <param name="Birthday" example="2001-05-23">Client birthday.</param>
/// <param name="Gender" example="Male">Client gender.</param>
/// <param name="Address">Client address.</param>
public record CreateClientDto(string Name, string Surname, DateOnly Birthday, string Gender, AddressDto Address);