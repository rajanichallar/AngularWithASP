using Microsoft.AspNetCore.Mvc;

namespace AngularWithASP.Server.Controllers
{
    [ApiController]
    [Route("api/test/[controller]")]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStatus()
        {
            return Ok(new { Status = "API is running", Timestamp = DateTime.UtcNow });
        }
    }
}
