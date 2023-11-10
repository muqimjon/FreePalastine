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
    public async ValueTask<IActionResult> CreateAsync([FromForm] ProductCreationDto dto)
    => Ok(new Response { Data = await services.ProductService.AddAsync(dto)});

    /// <summary>
    /// Update excist product
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut("update")]
    public async ValueTask<IActionResult> UpdateAsync([FromForm] ProductUpdateDto dto)
    => Ok(new Response { Data = await services.ProductService.ModifyAsync(dto) });

    /// <summary>
    /// Delete product by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("delete/{id:long}")]
    public async ValueTask<IActionResult> DeleteByIdAsync(long id)
    => Ok(new Response { Data = await services.ProductService.RemoveAsync(id) });

    /// <summary>
    /// Get product by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("get/{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    => Ok(new Response { Data = await services.ProductService.RetrieveByIdAsync(id) });

    /// <summary>
    /// Get all products
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-all")]
    public async ValueTask<IActionResult> GetAllAsync()
    => Ok(new Response { Data = await services.ProductService.RetrieveAllAsync()});

    /// <summary>
    /// Get products by name
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-by-name/{name}")]
    public async ValueTask<IActionResult> GetAllByNameAsync(string name)
    => Ok(new Response { Data = await services.ProductService.RetrieveAllByNameAsync(name)});
    
    /// <summary>
    /// Get products by country
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-by-country/{country}")]
    public async ValueTask<IActionResult> GetAllByCountryAsync(string country)
    => Ok(new Response { Data = await services.ProductService.RetrieveAllByCountryAsync(country)});


}