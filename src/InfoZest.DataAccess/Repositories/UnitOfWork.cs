using InfoZest.Domain.Entities;
using Microsoft.AspNetCore.Http;
using InfoZest.DataAccess.Contexts;
using InfoZest.DataAccess.IRepositories;

namespace InfoZest.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext appDbContext;
    public UnitOfWork(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
    {
        this.appDbContext = appDbContext;
        HttpContextAccessor = httpContextAccessor;
        AssetRepository = new Repository<Asset>(appDbContext);
        ProductRepository = new Repository<Product>(appDbContext);
        InvalidProductRepository = new Repository<InvalidProduct>(appDbContext);
        Dispose();
    }
    public IRepository<Asset> AssetRepository { get; }
    public IRepository<Product> ProductRepository { get; }
    public IHttpContextAccessor HttpContextAccessor { get; }  
    public IRepository<InvalidProduct> InvalidProductRepository { get; }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async ValueTask<bool> SaveAsync()
    => 0 < await appDbContext.SaveChangesAsync();
}