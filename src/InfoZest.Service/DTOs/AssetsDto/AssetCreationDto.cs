using Microsoft.AspNetCore.Http;

namespace InfoZest.Service.DTOs.AssetsDto;

public class AssetCreationDto
{
    public IFormFile FormFile { get; set; }
}