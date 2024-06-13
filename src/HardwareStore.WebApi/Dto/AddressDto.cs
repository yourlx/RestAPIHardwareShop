namespace HardwareStore.WebApi.DTO;

/// <summary>
/// Address DTO.
/// </summary>
/// <param name="Country">Country.</param>
/// <param name="City">City.</param>
/// <param name="Street">Street.</param>
public record AddressDto(string Country, string City, string Street);