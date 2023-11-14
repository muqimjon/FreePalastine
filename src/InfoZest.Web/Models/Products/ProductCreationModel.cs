namespace InfoZest.Web.Models;

public class ProductCreationModel
{
    public IFormFile formFile {get;set; }
    public string Name { get; set; }
    public string BarCode { get; set; }
    public string Description { get; set; }
    public string Brand { get; set; }
    public string Country { get; set; }
    public long AssetId { get; set; }
    public bool IsBoycott { get; set; }
    public bool IsHaram{ get; set; }
    public string Info { get; set; }
}
