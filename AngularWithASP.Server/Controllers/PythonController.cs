using Microsoft.AspNetCore.Mvc;

namespace AngularWithASP.Server.Controllers
{
    [ApiController]
    [Route("api/test/[controller]")]
    public class PythonController : Controller
    {
        [HttpGet("GetInfo")]
        public IActionResult GetInfo()
        {
            var info = new
            {
                Company = "Your Company Name",
                Mission = "Deliver high-quality software solutions",
                Founded = 2020
            };

            return Ok(info);
        }
    }
}
