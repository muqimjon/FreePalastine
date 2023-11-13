using InfoZest.Domain.Commons;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;

namespace InfoZest.Domain.Entities;

public class IHttpActionResultController : ApiController
{

    [SwaggerResponse((int)HttpStatusCode.OK, "List of customers", typeof(IEnumerable<int>))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(NotFoundResult))]
    public IHttpActionResult Post(Product data)
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// Product
/// </summary>
public class Product : Auditable
{
    /// <summary>
    /// Name 
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// BarCode
    /// </summary>
    public string BarCode { get; set; }
    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Brand
    /// </summary>
    public string Brand { get; set; }
    /// <summary>
    /// Country
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// Asset
    /// </summary>
    public long AssetId { get; set; }
    public Asset Asset { get; set; }
}