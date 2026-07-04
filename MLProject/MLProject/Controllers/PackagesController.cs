using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MLProject.Controllers
{
    [Route("api/PackagesController")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        [HttpGet("GetPackageName")]
      public  string GetPackageName()
        {
            return "الباقة الشاملة";
        }
    }
}
