using Microsoft.AspNetCore.Mvc;

namespace AngularWithASP.Server.Controllers
{
    [ApiController]
    [Route("api/test/[controller]")]
    public class ContactController : ControllerBase
    {
        [HttpPost]
        public IActionResult SubmitContact([FromBody] ContactFormModel model)
        {
            // Save or process contact form data
            return Ok(new { message = "Contact form submitted successfully!" });
        }
    }

    public class ContactFormModel
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Message { get; set; }
    }
}
