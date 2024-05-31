﻿namespace HardwareStore.WebApi.DTO;

public class SupplierDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public AddressDto Address { get; set; }
    
    public string PhoneNumber { get; set; }
}