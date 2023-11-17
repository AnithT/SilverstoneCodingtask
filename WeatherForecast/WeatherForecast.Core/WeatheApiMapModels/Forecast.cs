using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Core.WeatheApiMapModels
{
    public class Forecast
    {
        public List<Forecastday> forecastday { get; set; }
    }
}
