using Microsoft.AspNetCore.Mvc;

namespace AngularWithASP.Server.Controllers
{
    [ApiController]
    [Route("api/test/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
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
        //// 🆕 New Method: Get Forecast by Day Offset
        //[HttpGet("{daysAhead}")]
        //public IActionResult GetByDay(int daysAhead)
        //{
        //    if (daysAhead < 0 || daysAhead > 10)
        //        return BadRequest("Please provide a value between 0 and 10.");

        //    var forecast = new WeatherForecast
        //    {
        //        Date1 = DateTime.Now.AddDays(daysAhead),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    };

        //    return Ok(forecast);
        //}
        // 🆕 New Method: Get Forecast by Day Offset
        [HttpGet("GetByDay")]
        public IActionResult GetByDay([FromQuery] int daysAhead)
        {
            if (daysAhead < 0 || daysAhead > 10)
                return BadRequest("Please provide a value between 0 and 10.");

            var forecast = new WeatherForecast
            {
                Date1 = DateTime.Now.AddDays(daysAhead),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };

            return Ok(forecast);
        }
    }
}
