using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
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
using WeatherForecast.Infrastructure.Services;

namespace WeatherForecast.Unit_test
{
    public class WeatherForecast_UnitTest
    {
        [Fact]
        public async Task GetWeatherInfoAsync_SuccessfulRequest_ReturnsWeatherInfo()
        {
            // Arrange
            var mockRepository = new Mock<IWeatherRepository>();

            var configuration = new ConfigurationBuilder()
       .AddInMemoryCollection(new Dictionary<string, string>
       {
            {"WeatherApi:ApiKey", "d73721e68ee7449e9d4135327231711"},
            {"WeatherApi:ApiUrl", "http://api.weatherapi.com/v1/forecast.json"}
       })
       .Build();
            var weatherService = new WeatherService(mockRepository.Object, Options.Create(new WeatherApiOptions
            {
                ApiKey = configuration["WeatherApi:ApiKey"],
                ApiUrl = configuration["WeatherApi:ApiUrl"]
            }));
            var location = "London";

            var fakeWeatherData = new OpenWeatherMapResponse
            {
                // Set up fake data as needed
            };

            var fakeApiResponse = new RestResponse
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = JsonConvert.SerializeObject(fakeWeatherData)
            };

            var mockRestClient = new Mock<IRestClient>();
            mockRestClient.Setup(client => client.ExecuteAsync(It.IsAny<RestRequest>(), It.IsAny<CancellationToken>()))
          .ReturnsAsync(fakeApiResponse);

            // Act
            var result = await weatherService.GetWeatherInfoAsync(location);

            // Assert
              Assert.NotNull(result);
            // Add more assertions based on your requirements
        }

        [Fact]
        public async Task GetWeatherInfoAsync_FailedRequest_ThrowsException()
        {
            // Arrange
            var mockRepository = new Mock<IWeatherRepository>();
            var configuration = new ConfigurationBuilder()
     .AddInMemoryCollection(new Dictionary<string, string>
     {
            {"WeatherApi:ApiKey", "d73721e68ee7449e9d4135327231711"},
            {"WeatherApi:ApiUrl", "http://api.weatherapi.com/v1/forecast.json"}
     })
     .Build();
            var weatherService = new WeatherService(mockRepository.Object, Options.Create(new WeatherApiOptions
            {
                ApiKey = configuration["WeatherApi:ApiKey"],
                ApiUrl = configuration["WeatherApi:ApiUrl"]
            }));
            var location = "locationNotFound";

            var fakeApiResponse = new RestResponse
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = JsonConvert.SerializeObject(new WeatherApiException { Error = new Error { Message = "Fake error message" } })
            };

            var mockRestClient = new Mock<IRestClient>();
            mockRestClient.Setup(client => client.ExecuteAsync(It.IsAny<RestRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(fakeApiResponse);

            // Act and Assert
            await Assert.ThrowsAsync<Exception>(() => weatherService.GetWeatherInfoAsync(location));
        }

    }
}
