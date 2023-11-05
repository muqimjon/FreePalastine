using InfoZest.DataAccess.IRepositories;
using InfoZest.Service.DTOs.Products;
using InfoZest.Service.Interfaces;

namespace InfoZest.Service.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork unitOfWork;
    public ProductService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public ValueTask<ProductResultDto> AddAsync(ProductCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ProductResultDto> ModifyAsync(ProductUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<ProductResultDto>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<ProductResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}