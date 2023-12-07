using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IWeatherAgent
    {
        public Task<double[]> GetMonthlyWeather(int month, int year);
    }
}
