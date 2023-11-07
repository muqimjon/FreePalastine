using InfoZest.DataAccess.Contexts;
using InfoZest.DataAccess.IRepositories;
using InfoZest.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace InfoZest.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext appDbContext;
    public UnitOfWork(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
    {
        this.appDbContext = appDbContext;
        AssetRepository = new Repository<Asset>(appDbContext);
        ProductRepository = new Repository<Product>(appDbContext);
        InvalidProductRepository = new Repository<InvalidProduct>(appDbContext);
        Dispose();
        HttpContextAccessor = httpContextAccessor;
    }

    public IHttpContextAccessor HttpContextAccessor { get; set; }  
    public IRepository<Asset> AssetRepository { get; }
    public IRepository<Product> ProductRepository { get; }
    public IRepository<InvalidProduct> InvalidProductRepository { get; }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async ValueTask<bool> SaveAsync()
    => 0 < await appDbContext.SaveChangesAsync();
}