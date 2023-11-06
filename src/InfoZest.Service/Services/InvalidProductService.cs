using AutoMapper;
using InfoZest.Domain.Entities;
using Nabeey.Service.Exceptions;
using InfoZest.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using InfoZest.DataAccess.IRepositories;
using InfoZest.Service.DTOs.InvalidProducts;

namespace InfoZest.Service.Services;

public class InvalidProductService : IInvalidProductService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    public InvalidProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async ValueTask<InvalidProductResultDto> AddAsync(InvalidProductCreationDto dto)
    {
        var existInvalidProduct = await unitOfWork.InvalidProductRepository.SelectAsync(InvalidProduct =>
            InvalidProduct.ProductId.Equals(dto.ProductId));

        if (existInvalidProduct is not null)
            throw new AlreadyExistException("This InvalidProduct is already excist");

        var entity = mapper.Map<InvalidProduct>(dto);
        await unitOfWork.InvalidProductRepository.InsertAsync(entity);
        await unitOfWork.SaveAsync();
        return mapper.Map<InvalidProductResultDto>(entity);
    }

    public async ValueTask<InvalidProductResultDto> ModifyAsync(InvalidProductUpdateDto dto)
    {
        var entity = await unitOfWork.InvalidProductRepository.SelectAsync(InvalidProduct => InvalidProduct.Id.Equals(dto.Id)) ??
            throw new NotFoundException($"This InvalidProduct is not found with Id = {dto.Id}");

        mapper.Map(dto, entity);
        unitOfWork.InvalidProductRepository.Update(entity);
        await unitOfWork.SaveAsync();
        return mapper.Map<InvalidProductResultDto>(entity);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var entity = await unitOfWork.InvalidProductRepository.SelectAsync(InvalidProduct => InvalidProduct.Id.Equals(id)) ??
            throw new NotFoundException($"This InvalidProduct is not found with Id = {id}");

        unitOfWork.InvalidProductRepository.Destroy(entity);
        return await unitOfWork.SaveAsync();
    }

    public async ValueTask<IEnumerable<InvalidProductResultDto>> RetrieveAllAsync()
    {
        var entities = await unitOfWork.InvalidProductRepository.SelectAll().ToListAsync();
        return mapper.Map<IEnumerable<InvalidProductResultDto>>(entities);
    }

    public async ValueTask<InvalidProductResultDto> RetrieveByIdAsync(long id)
    {
        var entity = await unitOfWork.InvalidProductRepository.SelectAsync(InvalidProduct => InvalidProduct.Id.Equals(id)) ??
            throw new NotFoundException($"This InvalidProduct is not found with Id = {id}");

        return mapper.Map<InvalidProductResultDto>(entity);
    }
}
