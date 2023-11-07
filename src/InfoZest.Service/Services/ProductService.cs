using AutoMapper;
using InfoZest.Domain.Entities;
using InfoZest.Service.Exceptions;
using InfoZest.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using InfoZest.Service.DTOs.Products;
using InfoZest.DataAccess.IRepositories;

namespace InfoZest.Service.Services;

public class ProductService : IProductService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async ValueTask<ProductResultDto> AddAsync(ProductCreatioDto dto)
    {
        var existProduct = await unitOfWork.ProductRepository.SelectAsync(product =>
            product.Name.Equals(dto.Name, StringComparison.OrdinalIgnoreCase) ||
            product.BarCode.Equals(dto.BarCode, StringComparison.OrdinalIgnoreCase)) ;

        if(existProduct is not null)
            throw new AlreadyExistException("This Product is already excist");

        var entity = mapper.Map<Product>(dto);
        await unitOfWork.ProductRepository.InsertAsync(entity);
        await unitOfWork.SaveAsync();
        return mapper.Map<ProductResultDto>(entity);
    }

    public async ValueTask<ProductResultDto> ModifyAsync(ProductUpdateDto dto)
    {
        var entity = await unitOfWork.ProductRepository.SelectAsync(product => product.Id.Equals(dto.Id)) ??
            throw new NotFoundException($"This Product is not found with Id = {dto.Id}");

        mapper.Map(dto, entity);
        unitOfWork.ProductRepository.Update(entity);
        await unitOfWork.SaveAsync();
        return mapper.Map<ProductResultDto>(entity);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var entity = await unitOfWork.ProductRepository.SelectAsync(product => product.Id.Equals(id)) ??
            throw new NotFoundException($"This Product is not found with Id = {id}");

        unitOfWork.ProductRepository.Destroy(entity);
        return await unitOfWork.SaveAsync();
    }

    public async ValueTask<IEnumerable<ProductResultDto>> RetrieveAllAsync()
    {
        var entities = await unitOfWork.ProductRepository.SelectAll(includes: new[] { "Asset" }).ToListAsync();
        return mapper.Map<IEnumerable<ProductResultDto>>(entities);
    }

    public async ValueTask<ProductResultDto> RetrieveByIdAsync(long id)
    {
        var entity = await unitOfWork.ProductRepository.SelectAsync(product => product.Id.Equals(id), new[] { "Asset" }) ??
            throw new NotFoundException($"This Product is not found with Id = {id}");

        return mapper.Map<ProductResultDto>(entity);
    }
}
