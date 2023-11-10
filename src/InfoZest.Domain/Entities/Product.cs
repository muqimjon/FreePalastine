using InfoZest.Domain.Commons;

namespace InfoZest.Domain.Entities;

/// <summary>
/// Product
/// </summary>
public class Product : Auditable
{
    /// <summary>
    /// Name 
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// BarCode
    /// </summary>
    public string BarCode { get; set; }
    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Brand
    /// </summary>
    public string Brand { get; set; }
    /// <summary>
    /// Country
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// Asset
    /// </summary>
    public long AssetId { get; set; }
    public Asset Asset { get; set; }
}