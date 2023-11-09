using InfoZest.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using InfoZest.WebApi.Controllers.Commons;
using InfoZest.Service.Interfaces.Commons;
using InfoZest.Service.DTOs.InvalidProducts;

namespace InfoZest.WebApi.Controllers;

public class InvalidProductsController : BaseController
{
    public InvalidProductsController(IServices services) : base(services) { }

    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync([FromForm] InvalidProductCreationDto dto)
    => Ok(new Response { Data = await services.InvalidProductService.AddAsync(dto) });

    [HttpPut("update")]
    public async ValueTask<IActionResult> UpdateAsync([FromForm] InvalidProductUpdateDto dto)
    => Ok(new Response { Data = await services.InvalidProductService.ModifyAsync(dto) });

    [HttpDelete("delete/{id:long}")]
    public async ValueTask<IActionResult> DeleteByIdAsync(long id)
    => Ok(new Response { Data = await services.InvalidProductService.RemoveAsync(id) });

    [HttpGet("get/{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    => Ok(new Response { Data = await services.InvalidProductService.RetrieveByIdAsync(id) });

    [HttpGet("get-all")]
    public async ValueTask<IActionResult> GetAllAsync()
    => Ok(new Response { Data = await services.InvalidProductService.RetrieveAllAsync() });
}