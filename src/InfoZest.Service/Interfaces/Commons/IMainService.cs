using InfoZest.Service.DTOs.AssetsDto;

namespace InfoZest.Service.Interfaces.Commons;

public interface IMainService<TCreate, TUpdate, TResult>
{
    ValueTask<TResult> AddAsync(TCreate dto);
    ValueTask<TResult> ModifyAsync(TUpdate dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<IEnumerable<TResult>> RetrieveAllAsync();
    ValueTask<TResult> RetrieveByIdAsync(long id);
    ValueTask<TResult> UploadPhoto(AssetCreationDto dto, long id);
    ValueTask<TResult> ModifyPhoto(AssetCreationDto dto, long id);
}