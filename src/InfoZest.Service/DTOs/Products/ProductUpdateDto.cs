using Microsoft.AspNetCore.Http;

namespace InfoZest.Service.DTOs.Products;

public class ProductUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string BarCode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public IFormFile? Image { get; set; }
}
