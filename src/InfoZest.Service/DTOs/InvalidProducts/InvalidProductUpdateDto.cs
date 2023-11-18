using Microsoft.AspNetCore.Http;

namespace InfoZest.Service.DTOs.InvalidProducts;

public class InvalidProductUpdateDto
{
    public long Id { get; set; }
    public bool IsBoycott { get; set; }
    public bool IsHaram { get; set; }
    public string Info { get; set; } = string.Empty;
    public long ProductId { get; set; }
}
