using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Core.Entity
{
    public class WeatherInfo : User
    {
        public string LocationName { get; set; }
        public double Current_temperature { get; set; }
        public double Minimum_temperature { get; set; }
        public double Maximum_temperature { get; set; }
        public int Humidity { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
    }
}
