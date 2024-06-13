namespace HardwareStore.WebApi.DTO;

/// <summary>
/// Client DTO.
/// </summary>
/// <param name="Id">Client ID.</param>
/// <param name="Name">Client name.</param>
/// <param name="Surname">Client surname.</param>
/// <param name="Birthday">Client birthday.</param>
/// <param name="Gender">Client gender.</param>
/// <param name="Address">Client address.</param>
public record ClientDto(Guid Id, string Name, string Surname, DateOnly Birthday, string Gender, AddressDto Address);