﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Core.Entity;

namespace WeatherForecast.Core.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherInfo> GetWeatherInfoAsync(string location);
        Task<WeatherInfo> CreateAsync(WeatherInfo entity);
        Task <IEnumerable<WeatherInfo>> GetWeatherInfoByUser(int userId);
    }
}
