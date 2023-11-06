using InfoZest.Service.Interfaces.Commons;
using InfoZest.WebApi.Controllers.Commons;
using InfoZest.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoZest.WebApi.Controllers;

public class InvalidProductsController : BaseController
{
    public InvalidProductsController(IServices services) : base(services) { }

    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync(InvalidProductCreatioDto dto)
    => Ok(new Response { Data = await services.InvalidProductService.AddAsync(dto) });

    [HttpPost("update")]
    public async ValueTask<IActionResult> UpdateAsync(InvalidProductUpdateDto dto)
    => Ok(new Response { Data = await services.InvalidProductService.ModifyAsync(dto) });

    [HttpPost("delete/{ id: long }")]
    public async ValueTask<IActionResult> DeleteByIdAsync(long id)
    => Ok(new Response { Data = await services.InvalidProductService.RemoveAsync(id) });

    [HttpPost("get/{ id: long }")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    => Ok(new Response { Data = await services.InvalidProductService.RetrieveByIdAsync(id) });

    [HttpGet("get-all")]
    public async ValueTask<IActionResult> GetAllAsync()
    => Ok(new Response { Data = await services.InvalidProductService.RetrieveAllAsync() });
}