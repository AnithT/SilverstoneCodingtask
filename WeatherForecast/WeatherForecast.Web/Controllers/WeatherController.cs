using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherForecast.Core.Entity;
using WeatherForecast.Core.Interfaces;

namespace WeatherForecast.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        [HttpGet]
        public async Task<IActionResult> GetWeatherInfo(string location)
        {
           
                var weatherInfo = await _weatherService.GetWeatherInfoAsync(location);
                return Ok(weatherInfo);
           
        }

        [HttpPost]
        public async Task<ActionResult<WeatherInfo>> CreateWeatherDetails(WeatherInfo info)
        {
                await _weatherService.CreateAsync(info);

                return CreatedAtAction(nameof(GetWeatherInfoByUser), new { id = info.Id }, info);
        }

        // GET: api/Weather/User?1
        [HttpGet("User")]
        public async Task<ActionResult<IEnumerable<WeatherInfo>>> GetWeatherInfoByUser(int id)
        {
            var weatherInfo = await _weatherService.GetWeatherInfoByUser(id);

            if (weatherInfo == null)
            {
                return NotFound();
            }

            return Ok(weatherInfo);
        }
    }
}
