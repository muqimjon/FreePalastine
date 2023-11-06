using AutoMapper;
using InfoZest.Domain.Entities;
using Nabeey.Service.Exceptions;
using InfoZest.Service.Interfaces;
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
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async ValueTask<AssetResultDto> AddAsync(AssetCreationDto dto)
    {
        var entity = mapper.Map<Asset>(dto);
        await unitOfWork.AssetRepository.InsertAsync(entity);
        await unitOfWork.SaveAsync();
        return mapper.Map<AssetResultDto>(entity);
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