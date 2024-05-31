using AutoMapper;
using HardwareStore.WebApi.DTO;
using HardwareStore.WebApi.Models;

namespace HardwareStore.WebApi.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Address, AddressDto>().ReverseMap();

        CreateMap<Client, ClientDto>();
        CreateMap<CreateClientDto, Client>();

        CreateMap<Image, ImageDto>().ReverseMap();

        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductDto, Product>();

        CreateMap<Supplier, SupplierDto>();
        CreateMap<CreateSupplierDto, Supplier>();
    }
}