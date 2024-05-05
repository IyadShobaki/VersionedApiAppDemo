using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

// Missy way of versioning API
namespace VersionedApi.Controllers.v1;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
public class ValuesController : ControllerBase
{
   [HttpGet]
   public IEnumerable<string> Get()
   {
      return new string[] { "value1", "value2" };
   }
}
