using InfoZest.Domain.Entities;

namespace InfoZest.Service.DTOs.InvalidProducts;

public class InvalidProductResultDto
{
    public long Id { get; set; }
    public bool IsBoycott { get; set; }
    public bool IsHaram { get; set; }
    public string Info { get; set; }
    public Asset Asset { get; set; }
    public Product Product { get; set; }
}
