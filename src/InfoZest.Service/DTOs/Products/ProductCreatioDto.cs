namespace InfoZest.Service.DTOs.Products;

public class ProductCreatioDto
{
    public string Name { get; set; }
    public string BarCode { get; set; }
    public string Description { get; set; }
    public string Brand { get; set; }
    public string Country { get; set; }
    public long AssetId { get; set; }
}