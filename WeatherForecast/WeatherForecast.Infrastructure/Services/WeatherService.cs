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
        private readonly string apiKey = "d73721e68ee7449e9d4135327231711"; // Replace with your OpenWeatherMap API key
        private readonly string apiUrl = "http://api.weatherapi.com/v1/forecast.json";
        public async Task<WeatherInfo> GetWeatherInfoAsync(string location)
        {
            // Constructing the API request URL
            var apiUrlWithParams = $"{apiUrl}?key={apiKey} &q={location}&days=1&aqi=no&alerts=no";

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
                // Handle API request failure (e.g., log the error, throw an exception)
                throw new ApplicationException($"Failed to retrieve weather data. Status Code: {response.StatusCode}, Error: {response.ErrorMessage}");
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
