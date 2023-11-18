namespace InfoZest.Web.Models.Products;

public class InvalidProductViewModel
{
    public bool IsBoycott { get; set; }
    public bool IsHaram{ get; set; }
    public string Info { get; set; }
    public long AssetId { get; set; }
    public long ProductId { get; set; }
}


