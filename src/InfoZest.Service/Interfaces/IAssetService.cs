using InfoZest.Service.DTOs.AssetsDto;

namespace InfoZest.Service.Interfaces;

public interface IAssetService
{
    ValueTask<AssetResultDto> AddAsync(AssetCreationDto dto);
    ValueTask<AssetResultDto> ModifyAsync(AssetUpdateDto dto);
    ValueTask<AssetResultDto> RetrieveByIdAsync(long id);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<IEnumerable<AssetResultDto>> RetrieveAllAsync();
}