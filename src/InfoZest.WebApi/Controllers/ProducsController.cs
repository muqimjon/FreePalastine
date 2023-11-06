using InfoZest.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using InfoZest.Service.DTOs.Products;
using InfoZest.Service.Interfaces.Commons;
using InfoZest.WebApi.Controllers.Commons;

namespace InfoZest.WebApi.Controllers;

public class ProductsController : BaseController
{
    public ProductsController(IServices services) : base(services) { }

    /// <summary>
    /// Add new product
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync(ProductCreatioDto dto)
    => Ok(new Response { Data = await services.ProductService.AddAsync(dto)});

    /// <summary>
    /// Update excist product
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("update")]
    public async ValueTask<IActionResult> UpdateAsync(ProductUpdateDto dto)
    => Ok(new Response { Data = await services.ProductService.ModifyAsync(dto) });

    /// <summary>
    /// Delete product by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost("delete/{id:long}")]
    public async ValueTask<IActionResult> DeleteByIdAsync(long id)
    => Ok(new Response { Data = await services.ProductService.RemoveAsync(id) });

    /// <summary>
    /// Get product by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost("get/{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    => Ok(new Response { Data = await services.ProductService.RetrieveByIdAsync(id) });

    /// <summary>
    /// Get all products
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-all")]
    public async ValueTask<IActionResult> GetAllAsync()
    => Ok(new Response { Data = await services.ProductService.RetrieveAllAsync()});
}