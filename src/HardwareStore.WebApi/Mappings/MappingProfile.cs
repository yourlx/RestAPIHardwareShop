using AutoMapper;
using HardwareStore.WebApi.DTO;
using HardwareStore.WebApi.Models;

namespace HardwareStore.WebApi.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<Client, ClientDto>().ReverseMap();
        CreateMap<Image, ImageDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Supplier, SupplierDto>().ReverseMap();
    }
}