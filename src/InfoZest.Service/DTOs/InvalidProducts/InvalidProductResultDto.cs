using InfoZest.Domain.Entities;
using InfoZest.Service.DTOs.AssetsDto;

namespace InfoZest.Service.DTOs.InvalidProducts;

public class InvalidProductResultDto
{
    public long Id { get; set; }
    public bool IsBoycott { get; set; }
    public bool IsHaram { get; set; }
    public string Info { get; set; }
    public AssetResultDto Asset { get; set; }
    public Product Product { get; set; }
}
