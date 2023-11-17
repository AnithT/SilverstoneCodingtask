using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Core.WeatheApiMapModels
{
    public class Current
    {
        public double temp_c { get; set; }
        public int humidity { get; set; }
    }
}
