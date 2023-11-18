using InfoZest.Domain.Commons;

namespace InfoZest.Domain.Entities;

public class InvalidProduct : Auditable
{
    public bool IsBoycott { get; set; }
    public bool IsHaram{ get; set; }
    public string Info { get; set; }

    public long ProductId { get; set; }
    public Product Product { get; set; }
}