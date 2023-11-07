using InfoZest.Service.DTOs.AssetsDto;

namespace InfoZest.Service.Interfaces;

public interface IAssetService
{
    ValueTask<AssetResultDto> AddAsync(AssetCreationDto dto);
    ValueTask<bool> RemoveAsync(long id);
}