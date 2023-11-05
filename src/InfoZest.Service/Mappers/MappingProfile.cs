using AutoMapper;
using InfoZest.Domain.Entities;
using InfoZest.Service.DTOs.Assets;
using InfoZest.Service.DTOs.Products;
using InfoZest.Service.DTOs.InvalidProducts;

namespace InfoZest.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Asset
        CreateMap<Asset, AssetResultDto>();
        CreateMap<AssetUpdateDto, Asset>();

        // Product
        CreateMap<Product, ProductResultDto>();
        CreateMap<ProductUpdateDto, Product>();
        CreateMap<ProductCreateDto, Product>();

        // Invalid Product
        CreateMap<InvalidProduct, InvalidProductResultDto>();
        CreateMap<InvalidProductCreationDto, InvalidProduct>();
        CreateMap<InvalidProductUpdateDto, InvalidProduct>();
    }
}