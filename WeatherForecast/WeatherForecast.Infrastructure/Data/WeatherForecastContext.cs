using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Core.Entity;

namespace WeatherForecast.Infrastructure.Data
{
    public class WeatherForecastContext : DbContext
    {
        public WeatherForecastContext(DbContextOptions<WeatherForecastContext> options) : base(options) { }
        public virtual DbSet<WeatherInfo> WeatherInfo { get; set; }
    }
}
