using InfoZest.Service.DTOs.Assets;

namespace InfoZest.Service.Interfaces;

public interface IAssetService
{
    ValueTask<AssetResultDto> ModifyAsync(AssetUpdateDto dto);
    ValueTask<AssetResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<AssetUpdateDto>> GetAllAsync();
}