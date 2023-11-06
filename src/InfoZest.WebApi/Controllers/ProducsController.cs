using InfoZest.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using InfoZest.Service.DTOs.Products;
using InfoZest.Service.Interfaces.Commons;
using InfoZest.WebApi.Controllers.Commons;

namespace InfoZest.WebApi.Controllers;

public class ProductsController : BaseController
{
    public ProductsController(IServices services) : base(services) { }

    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync(ProductCreatioDto dto)
    => Ok(new Response { Data = await services.ProductService.AddAsync(dto)});

    [HttpPost("update")]
    public async ValueTask<IActionResult> UpdateAsync(ProductUpdateDto dto)
    => Ok(new Response { Data = await services.ProductService.ModifyAsync(dto) });

    [HttpPost("delete/{id:long}")]
    public async ValueTask<IActionResult> DeleteByIdAsync(long id)
    => Ok(new Response { Data = await services.ProductService.RemoveAsync(id) });

    [HttpPost("get/{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    => Ok(new Response { Data = await services.ProductService.RetrieveByIdAsync(id) });

    [HttpGet("get-all")]
    public async ValueTask<IActionResult> GetAllAsync()
    => Ok(new Response { Data = await services.ProductService.RetrieveAllAsync()});
}