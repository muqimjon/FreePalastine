using InfoZest.Service.DTOs.AssetsDto;

namespace InfoZest.Service.DTOs.Products;

public class ProductResultDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string BarCode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public AssetResultDto Asset { get; set; } = default!;
}