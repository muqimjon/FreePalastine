using AutoMapper;
using InfoZest.Domain.Entities;
using InfoZest.Service.Interfaces;
using InfoZest.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using InfoZest.Service.DTOs.Products;
using InfoZest.Service.DTOs.AssetsDto;
using InfoZest.DataAccess.IRepositories;

namespace InfoZest.Service.Services;

public class ProductService : IProductService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    private readonly IAssetService assetService;
    public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IAssetService assetService)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.assetService = assetService;
    }

    public async ValueTask<ProductResultDto> AddAsync(ProductCreationDto dto)
    {
        var existProduct = await unitOfWork.ProductRepository.SelectAsync(product =>
            product.Name.Equals(dto.Name, StringComparison.OrdinalIgnoreCase) ||
            product.BarCode.Equals(dto.BarCode, StringComparison.OrdinalIgnoreCase)) ;

        if(existProduct is not null)
            throw new AlreadyExistException("This Product is already excist");

        var entity = mapper.Map<Product>(dto);
        if (dto.Image is not null)
        {
            var uploadedImage = await this.assetService.UploadAsync(new AssetCreationDto { FormFile = dto.Image });
            var createImage = new Asset()
            {
                FileName = uploadedImage.FileName,
                FilePath = uploadedImage.FilePath,
            };

            entity.AssetId = uploadedImage.Id;
            entity.Asset = createImage;
        }

        await unitOfWork.ProductRepository.InsertAsync(entity);
        await unitOfWork.SaveAsync();
        return mapper.Map<ProductResultDto>(entity);
    }

    public async ValueTask<ProductResultDto> ModifyAsync(ProductUpdateDto dto)
    {
        var entity = await unitOfWork.ProductRepository.SelectAsync(product => product.Id.Equals(dto.Id)) ??
            throw new NotFoundException($"This Product is not found with Id = {dto.Id}");

        if(entity.Asset is not null)
            await assetService.RemoveAsync(entity.Asset.Id);

        mapper.Map(dto, entity);
        if (dto.Image is not null)
        {
            var uploadedImage = await this.assetService.UploadAsync(new AssetCreationDto { FormFile = dto.Image });
            var createImage = new Asset()
            {
                FileName = uploadedImage.FileName,
                FilePath = uploadedImage.FilePath,
            };

            entity.AssetId = uploadedImage.Id;
            entity.Asset = createImage;
        }

        await unitOfWork.ProductRepository.InsertAsync(entity);
        await unitOfWork.SaveAsync();
        return mapper.Map<ProductResultDto>(entity);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var entity = await unitOfWork.ProductRepository.SelectAsync(product => product.Id.Equals(id)) ??
            throw new NotFoundException($"This Product is not found with Id = {id}");

        if (entity.Asset is not null)
            await assetService.RemoveAsync(entity.Asset.Id);

        unitOfWork.ProductRepository.Destroy(entity);
        return await unitOfWork.SaveAsync();
    }

    public async ValueTask<IEnumerable<ProductResultDto>> RetrieveAllAsync()
    {
        var entities = await unitOfWork.ProductRepository.SelectAll(includes: new[] { "Asset" }).ToListAsync();
        return mapper.Map<IEnumerable<ProductResultDto>>(entities);
    }

    public async ValueTask<ProductResultDto> RetrieveByIdAsync(long id)
    {
        var entity = await unitOfWork.ProductRepository.SelectAsync(product => product.Id.Equals(id), new[] { "Asset" }) ??
            throw new NotFoundException($"This Product is not found with Id = {id}");

        return mapper.Map<ProductResultDto>(entity);
    }
}
