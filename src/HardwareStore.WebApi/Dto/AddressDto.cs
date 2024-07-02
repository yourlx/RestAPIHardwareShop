namespace HardwareStore.WebApi.DTO;

/// <summary>
/// Address DTO.
/// </summary>
/// <param name="Country" example="France">Country.</param>
/// <param name="City" example="Paris">City.</param>
/// <param name="Street" example="Champs-Élysées">Street.</param>
public record AddressDto(string Country, string City, string Street);