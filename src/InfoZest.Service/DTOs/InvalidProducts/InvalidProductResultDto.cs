using InfoZest.Domain.Entities;
using InfoZest.Service.DTOs.AssetsDto;

namespace InfoZest.Service.DTOs.InvalidProducts;

public class InvalidProductResultDto
{
    public long Id { get; set; }
    public bool IsBoycott { get; set; }
    public bool IsHaram { get; set; }
    public string Info { get; set; } = string.Empty;
    public AssetResultDto Asset { get; set; } = default!;
    public Product Product { get; set; } = default!;
}
