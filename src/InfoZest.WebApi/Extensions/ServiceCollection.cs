using InfoZest.DataAccess.IRepositories;
using InfoZest.DataAccess.Repositories;
using InfoZest.Service.Interfaces;
using InfoZest.Service.Interfaces.Commons;
using InfoZest.Service.Mappers;
using InfoZest.Service.Services;
using InfoZest.Service.Services.Commons;

namespace InfoZest.WebApi.Extensions;

public static class ServiceCollection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddScoped<IServices, Services>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAssetService, AssetService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IInvalidProductService, InvalidProductService>();
    }
}
