using AutoMapper;
using InfoZest.DataAccess.IRepositories;
using InfoZest.Service.DTOs.Assets;
using InfoZest.Service.Interfaces;

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

    public ValueTask<IEnumerable<AssetUpdateDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<AssetResultDto> ModifyAsync(AssetUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<AssetResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}