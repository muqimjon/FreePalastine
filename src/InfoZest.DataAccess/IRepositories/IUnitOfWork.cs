using InfoZest.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace InfoZest.DataAccess.IRepositories;

public interface IUnitOfWork : IDisposable
{
    IRepository<Asset> AssetRepository {  get; }
    IRepository<Product> ProductRepository {  get; }
    IRepository<InvalidProduct> InvalidProductRepository {  get; }
    IHttpContextAccessor HttpContextAccessor { get; }
    ValueTask<bool> SaveAsync();
}