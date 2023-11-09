using AutoMapper;
using InfoZest.Domain.Entities;
using InfoZest.Service.Exceptions;
using InfoZest.Service.Extensions;
using InfoZest.Service.Interfaces;
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

    public async ValueTask<AssetResultDto> UploadAsync(AssetCreationDto dto)
    {
        var webRootPath = Path.Combine(PathHelper.WebRootPath, "image");

        if (!Directory.Exists(webRootPath))
            Directory.CreateDirectory(webRootPath);

        var fileExtention = Path.GetExtension(dto.FormFile.FileName);
        var fileName = $"{Guid.NewGuid().ToString("N")}{fileExtention}";
        var filePath = Path.Combine(webRootPath, fileName);

        var fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
        await fileStream.WriteAsync(dto.FormFile.ToByte());
        await dto.FormFile.CopyToAsync(fileStream);

        var imageUrl = $"{unitOfWork.HttpContextAccessor.HttpContext.Request.Scheme}:" +
            $"//{unitOfWork.HttpContextAccessor.HttpContext.Request.Host}/image/{fileName}";

        var asset = new Asset()
        {
            FileName = fileName,
            FilePath = imageUrl,
        };

        await unitOfWork.AssetRepository.InsertAsync(asset);
        await unitOfWork.SaveAsync();
        return mapper.Map<AssetResultDto>(asset);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var entity = await unitOfWork.AssetRepository.SelectAsync(Asset => Asset.Id.Equals(id)) ??
            throw new NotFoundException($"This asset is not found with Id = {id}");

        var pathPhoto = Path.Combine(PathHelper.WebRootPath, "images", entity.FileName);
        File.Delete(pathPhoto);

        unitOfWork.AssetRepository.Destroy(entity);
        return await unitOfWork.SaveAsync();
    }
}
