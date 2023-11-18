using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Core.Entity;
using WeatherForecast.Core.Interfaces;
using WeatherForecast.Infrastructure.Data;

namespace WeatherForecast.Infrastructure.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly WeatherForecastContext _context;
        public WeatherRepository(WeatherForecastContext context)
        {
            _context = context;
        }

        public async Task<WeatherInfo> CreateAsync(WeatherInfo entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<WeatherInfo>> GetByIdAsync(int Id)
        {

            return await _context.WeatherInfo.Where(x => x.UserId == Id).ToListAsync();

        }
    }
}
