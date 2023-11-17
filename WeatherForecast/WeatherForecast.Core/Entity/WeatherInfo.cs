using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Core.Entity
{
    public class WeatherInfo
    {
        public string LocationName { get; set; }
        public double Temperature { get; set; }
        public int Humidity { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
    }
}
