using InfoZest.Service.DTOs.AssetsDto;
using InfoZest.Service.Interfaces.Commons;
using InfoZest.WebApi.Controllers.Commons;
using InfoZest.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoZest.WebApi.Controllers;

public class AssetsController : BaseController
{
    public AssetsController(IServices services) : base(services) { }

    [HttpPost("update")]
    public async ValueTask<IActionResult> UpdateAsync(AssetUpdateDto dto)
    => Ok(new Response { Data = await services.AssetService.ModifyAsync(dto) });

    [HttpDelete("delete/{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    => Ok(new Response { Data = await services.AssetService.RemoveAsync(id) });

    [HttpGet("get/{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    => Ok(new Response { Data = await services.AssetService.RetrieveByIdAsync(id) });

    [HttpGet("get-all")]
    public async ValueTask<IActionResult> GetAllAsync()
    => Ok(new Response { Data = await services.AssetService.RetrieveAllAsync() });
}
