using InfoZest.Service.Interfaces.Commons;
using Microsoft.AspNetCore.Mvc;

namespace InfoZest.WebApi.Controllers.Commons;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected IServices services;
    public BaseController(IServices services)
    {
        this.services = services;
    }
}
