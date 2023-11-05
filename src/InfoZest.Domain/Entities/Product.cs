using InfoZest.Domain.Commons;

namespace InfoZest.Domain.Entities;

public class Product : Auditable
{
    public string Name { get; set; }
    public string BarCode { get; set; }
    public string Description { get; set; }
    public string Brand { get; set; }
    public string Country { get; set; }

    public long AssetId { get; set; }
    public Asset Asset { get; set; }
}