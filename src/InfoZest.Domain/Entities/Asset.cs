using InfoZest.Domain.Commons;

namespace InfoZest.Domain.Entities;

public class Asset : Auditable
{
    public string FileName { get; set; }
    public string FilePath { get; set; }
}