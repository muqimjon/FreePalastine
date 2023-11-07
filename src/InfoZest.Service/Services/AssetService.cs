using AutoMapper;
using InfoZest.Domain.Entities;
using Nabeey.Service.Exceptions;
using InfoZest.Service.Interfaces;
using InfoZest.Service.Extensions;
using Microsoft.EntityFrameworkCore;
using InfoZest.Service.DTOs.AssetsDto;
using InfoZest.DataAccess.IRepositories;

namespace InfoZest.Service.Services;

public class AssetService : IAssetService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    public AssetService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async ValueTask<AssetResultDto> AddAsync(AssetCreationDto dto)
    {
        var webRootPath = Path.Combine(PathHelper.WebRootPath, "Image");

        if (!Directory.Exists(webRootPath))
            Directory.CreateDirectory(webRootPath);

        var fileExtention = Path.GetExtension(dto.FormFile.FileName);
        var fileName = $"{Guid.NewGuid().ToString("N")}{fileExtention}";
        var filePath = Path.Combine(webRootPath, fileName);

        var fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
        await fileStream.WriteAsync(dto.FormFile.ToByte());
        await dto.FormFile.CopyToAsync(fileStream);

        var imageUrl = $"{unitOfWork.HttpContextAccessor.HttpContext.Request.Scheme}://{unitOfWork.HttpContextAccessor.HttpContext.Request.Host}/image/{fileName}";

        var asset = new Asset()
        {
            FileName = fileName,
            FilePath = imageUrl,
        };

        await unitOfWork.AssetRepository.InsertAsync(asset);
        await unitOfWork.SaveAsync();
        return mapper.Map<AssetResultDto>(dto);
    }

    public async ValueTask<bool> RemoveAsync(Asset asset)
    {
        var entity = asset is null ? default :
            await unitOfWork.AssetRepository.SelectAsync(a => a.Id.Equals(asset.Id));
        
        if (entity is null)
            return false;

        unitOfWork.AssetRepository.Destroy(entity);
        return await unitOfWork.SaveAsync();
    }

    public async ValueTask<AssetResultDto> ModifyAsync(AssetUpdateDto dto)
    {
        var entity = await unitOfWork.AssetRepository.SelectAsync(Asset => Asset.Id.Equals(dto.Id)) ??
            throw new NotFoundException($"This asset is not found with Id = {dto.Id}");

        mapper.Map(dto, entity);
        unitOfWork.AssetRepository.Update(entity);
        await unitOfWork.SaveAsync();
        return mapper.Map<AssetResultDto>(entity);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var entity = await unitOfWork.AssetRepository.SelectAsync(Asset => Asset.Id.Equals(id)) ??
            throw new NotFoundException($"This asset is not found with Id = {id}");

        unitOfWork.AssetRepository.Destroy(entity);
        return await unitOfWork.SaveAsync();
    }

    public async ValueTask<IEnumerable<AssetResultDto>> RetrieveAllAsync()
    {
        var entities = await unitOfWork.AssetRepository.SelectAll().ToListAsync();
        return mapper.Map<IEnumerable<AssetResultDto>>(entities);
    }

    public async ValueTask<AssetResultDto> RetrieveByIdAsync(long id)
    {
        var entity = await unitOfWork.AssetRepository.SelectAsync(Asset => Asset.Id.Equals(id)) ??
            throw new NotFoundException($"This asset is not found with Id = {id}");

        return mapper.Map<AssetResultDto>(entity);
    }
}
