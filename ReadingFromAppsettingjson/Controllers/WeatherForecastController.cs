using Microsoft.AspNetCore.Mvc;
using ReadingFromAppsettingjson.Models;

namespace ReadingFromAppsettingjson.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Links link;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, Links link)
        {
            _logger = logger;
            this.link = link;
        }

        [HttpGet("getLinks")]
        public IActionResult getLinks() {
            return Ok(new { 
                instagram = link.instagram,
                youtube = link.youtube
            });
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
    }
}
