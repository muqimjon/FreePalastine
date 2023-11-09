using InfoZest.Service.Interfaces;
using InfoZest.Service.Interfaces.Commons;

namespace InfoZest.Service.Services.Commons;

public class Services : IServices
{
    public Services(IAssetService assetService,
        IProductService productService,
        IInvalidProductService invalidProductService)
    {
        AssetService = assetService;
        ProductService = productService;
        InvalidProductService = invalidProductService;
        Dispose();
    }

    public IAssetService AssetService { get; }
    public IProductService ProductService { get; }
    public IInvalidProductService InvalidProductService { get; }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}