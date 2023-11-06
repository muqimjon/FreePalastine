using AutoMapper;
using InfoZest.Domain.Entities;
using InfoZest.Service.DTOs.Products;
using InfoZest.Service.DTOs.AssetsDto;
using InfoZest.Service.DTOs.InvalidProducts;

namespace InfoZest.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Asset
        CreateMap<Asset, AssetResultDto>();
        CreateMap<AssetUpdateDto, Asset>();
        CreateMap<AssetCreationDto, Asset>();

        // Product
        CreateMap<Product, ProductResultDto>();
        CreateMap<ProductUpdateDto, Product>();
        CreateMap<ProductCreatioDto, Product>();

        // Invalid Product
        CreateMap<InvalidProduct, InvalidProductResultDto>();
        CreateMap<InvalidProductUpdateDto, InvalidProduct>();
        CreateMap<InvalidProductCreationDto, InvalidProduct>();
    }
}