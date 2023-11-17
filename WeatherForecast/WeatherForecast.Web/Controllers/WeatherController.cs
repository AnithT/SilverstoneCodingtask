using Microsoft.AspNetCore.Mvc;
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
            try
            {
                var weatherInfo = await _weatherService.GetWeatherInfoAsync(location);
                return Ok(weatherInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
