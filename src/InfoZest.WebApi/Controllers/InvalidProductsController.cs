using InfoZest.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using InfoZest.WebApi.Controllers.Commons;
using InfoZest.Service.Interfaces.Commons;
using InfoZest.Service.DTOs.InvalidProducts;

namespace InfoZest.WebApi.Controllers;

public class InvalidProductsController : BaseController
{
    public InvalidProductsController(IServices services) : base(services) { }

    /// <summary>
    /// Add new invalid product
    /// </summary>
    /// <param name="dto">The DTO containing additional information for the invalid product</param>
    /// <returns>Returns the result DTO of the created invalid product</returns>
    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync([FromForm] InvalidProductCreationDto dto)
    => Ok(new Response { Data = await services.InvalidProductService.AddAsync(dto) });

    /// <summary>
    /// Update excist invalid product
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut("update")]
    public async ValueTask<IActionResult> UpdateAsync([FromForm] InvalidProductUpdateDto dto)
    => Ok(new Response { Data = await services.InvalidProductService.ModifyAsync(dto) });

    /// <summary>
    /// Delete invalid product by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("delete/{id:long}")]
    public async ValueTask<IActionResult> DeleteByIdAsync(long id)
    => Ok(new Response { Data = await services.InvalidProductService.RemoveAsync(id) });

    /// <summary>
    /// Get invalid product by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("get/{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    => Ok(new Response { Data = await services.InvalidProductService.RetrieveByIdAsync(id) });

    /// <summary>
    /// Get all invalid products
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-all")]
    public async ValueTask<IActionResult> GetAllAsync()
    => Ok(new Response { Data = await services.InvalidProductService.RetrieveAllAsync() });
}