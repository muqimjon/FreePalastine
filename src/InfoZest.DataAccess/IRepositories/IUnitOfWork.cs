using InfoZest.Domain.Entities;

namespace InfoZest.DataAccess.IRepositories;

public interface IUnitOfWork : IDisposable
{
     IRepository<Asset> AssetRepository {  get; }
     IRepository<Product> ProductRepository {  get; }
     IRepository<InvalidProduct> InvalidProductRepository {  get; }
}