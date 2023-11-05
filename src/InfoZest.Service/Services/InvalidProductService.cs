﻿using AutoMapper;
using InfoZest.DataAccess.IRepositories;
using InfoZest.Service.DTOs.InvalidProducts;
using InfoZest.Service.Interfaces;

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

    public ValueTask<InvalidProductResultDto> AddAsync(InvalidProductUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<InvalidProductResultDto> ModifyAsync(InvalidProductUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<InvalidProductResultDto>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<InvalidProductResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}