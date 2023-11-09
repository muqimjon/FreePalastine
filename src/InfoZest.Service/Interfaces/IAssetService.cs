using InfoZest.Service.DTOs.AssetsDto;

namespace InfoZest.Service.Interfaces;

public interface IAssetService
{
    ValueTask<AssetResultDto> UploadAsync(AssetCreationDto dto);
    ValueTask<bool> RemoveAsync(long id);
}