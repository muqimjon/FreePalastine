using InfoZest.DataAccess.IRepositories;
using InfoZest.DataAccess.Repositories;
using InfoZest.Service.Interfaces.Commons;
using InfoZest.Service.Interfaces;
using InfoZest.Service.Mappers;
using InfoZest.Service.Services.Commons;
using InfoZest.Service.Services;

namespace InfoZest.Web.Exstention;

public static class ServiceCollection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IServices, Services>();
        services.AddScoped<IAssetService, AssetService>();
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IInvalidProductService, InvalidProductService>();
        services.AddHttpContextAccessor();
    }
}
