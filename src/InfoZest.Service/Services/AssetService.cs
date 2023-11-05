using InfoZest.DataAccess.IRepositories;
using InfoZest.Service.DTOs.Assets;
using InfoZest.Service.Interfaces;

namespace InfoZest.Service.Services;

public class AssetService : IAssetService
{
    private readonly IUnitOfWork unitOfWork;
    public AssetService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
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