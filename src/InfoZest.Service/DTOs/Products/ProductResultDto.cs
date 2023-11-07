using InfoZest.Service.DTOs.AssetsDto;

namespace InfoZest.Service.DTOs.Products;

public class ProductResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string BarCode { get; set; }
    public string Description { get; set; }
    public string Brand { get; set; }
    public string Country { get; set; }
    public AssetResultDto Asset { get; set; }
}