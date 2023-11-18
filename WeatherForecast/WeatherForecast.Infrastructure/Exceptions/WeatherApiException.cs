using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Infrastructure.Exceptions
{
    public class WeatherApiException : Exception
    {
        public WeatherApiException(string message) : base(message)
        {
        }
    }
}
