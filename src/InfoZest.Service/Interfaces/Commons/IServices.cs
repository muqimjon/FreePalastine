namespace InfoZest.Service.Interfaces.Commons;

public interface IServices : IDisposable
{
    IAssetService AssetService { get; }
    IProductService ProductService { get; }
    IInvalidProductService InvalidProductService { get; }
}