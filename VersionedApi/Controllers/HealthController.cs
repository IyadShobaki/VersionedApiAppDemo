using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

// Version Neutral Endpoints   (Version independent) 
namespace VersionedApi.Controllers
{
   // We put th version in the url but it doesn't matter the version we choose
   // It will give you the health of the API
   [Route("api/v{version:apiVersion}/[controller]")]
   [ApiController]
   [ApiVersionNeutral]
   public class HealthController : ControllerBase
   {
      [HttpGet]
      [Route("ping")]
      public IActionResult Ping()
      {
         return Ok("Everything seems great!");
      }
   }
}
