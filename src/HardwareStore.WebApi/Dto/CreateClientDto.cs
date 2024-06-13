namespace HardwareStore.WebApi.DTO;

/// <summary>
/// Create Client DTO.
/// </summary>
/// <param name="Name">Client name.</param>
/// <param name="Surname">Client surname.</param>
/// <param name="Birthday">Client birthday.</param>
/// <param name="Gender">Client gender.</param>
/// <param name="Address">Client address.</param>
public record CreateClientDto(string Name, string Surname, DateOnly Birthday, string Gender, AddressDto Address);