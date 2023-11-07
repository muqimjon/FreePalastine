using Microsoft.AspNetCore.Http;

namespace InfoZest.Service.DTOs.AssetsDto;

public class AssetUpdateDto
{
    public long Id { get; set; }
    public IFormFile FormFile { get; set; }
}