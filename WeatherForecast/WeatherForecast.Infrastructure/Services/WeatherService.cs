using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Core.Entity;
using WeatherForecast.Core.Interfaces;
using WeatherForecast.Core.WeatheApiMapModels;

namespace WeatherForecast.Infrastructure.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;
        private readonly WeatherApiOptions _weatherApiOptions;

        public WeatherService(IWeatherRepository weatherRepository, IOptions<WeatherApiOptions> weatherApiOptions)
        {
            _weatherRepository = weatherRepository;
            _weatherApiOptions = weatherApiOptions.Value;
        }

        public async Task<WeatherInfo> CreateAsync(WeatherInfo entity)
        {
            return await _weatherRepository.CreateAsync(entity);
        }
        public async Task <IEnumerable<WeatherInfo>> GetWeatherInfoByUser(int userId)
        {
            return await _weatherRepository.GetByIdAsync(userId);
        }

        public async Task<WeatherInfo> GetWeatherInfoAsync(string location)
        {
            // Constructing the API request URL
            var apiUrlWithParams = $"{_weatherApiOptions.ApiUrl}?key={_weatherApiOptions.ApiKey} &q={location}&days=1&aqi=no&alerts=no";

            // Using RestSharp to make the API request
            var client = new RestClient(apiUrlWithParams);
            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteAsync(request);

            // Check if the request was successful
            if (response.IsSuccessful)
            {
                // Parsing the JSON response and map it to the WeatherInfo model
                var weatherData = JsonConvert.DeserializeObject<OpenWeatherMapResponse>(response.Content);
                var weatherInfo = MapToWeatherInfo(weatherData);

                return weatherInfo;
            }
            else
            {
                var exceptionData = JsonConvert.DeserializeObject<WeatherApiException>(response.Content);
                throw new Exception($"{exceptionData.Error.Message}");
            }
        }
        private WeatherInfo MapToWeatherInfo(OpenWeatherMapResponse weatherData)
        {
            // Mapping OpenWeatherMap API response to your WeatherInfo model
            // Extracting relevant information like temperature, humidity, sunrise, sunset, etc.
            return new WeatherInfo
            {
                LocationName = weatherData.location.Name,
                Current_temperature = weatherData.current.temp_c,
                Humidity = weatherData.current.humidity,
                Maximum_temperature = weatherData.forecast.forecastday[0].Day.maxtemp_c,
                Minimum_temperature = weatherData.forecast.forecastday[0].Day.mintemp_c
            };
        }       
    }
}
