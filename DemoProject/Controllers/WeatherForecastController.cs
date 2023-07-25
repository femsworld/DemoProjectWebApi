using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
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
        private NameService NameService { get; set; }

        public WeatherForecastController(ILogger<WeatherForecastController> logger, NameService nameService)
        {
            _logger = logger;
            //NameService = new NameService();
            NameService = nameService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            throw new InvalidNameException();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost(Name ="PostWeatherForcast")]
        public async Task<IActionResult> Post()
        {
            //Post logic here
            return Ok("Weatherforcast posted");
        }
        [HttpPut(Name = "PutWeatherForcast")]
        public async Task<IActionResult> Put(WeatherForecast weatherForecast)
        {
            //Put logic here
            return Ok("Weatherforcast updated");
        }
        [HttpDelete(Name = "DeleteWeatherForcast")]
        public async Task<IActionResult> Delete(int id)
        {
            //Delete logic here
            return Ok("Weatherforcast deleted");
        }
    }
}