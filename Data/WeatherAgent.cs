using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data
{
    public class WeatherAgent : IWeatherAgent
    {
        private readonly IConfiguration _configuration;
        private readonly string _url;

        public WeatherAgent(IConfiguration configuration)
        {
            _configuration = configuration;
            _url = _configuration["ConnectionStrings:WeatherStation"];
        }
        public async Task<double[]> GetMontlyWeather(int month, int year)
        {
            var options = new RestClientOptions(_url);
            var client = new RestClient(options);
            var request = new RestRequest("/Weather/WeatherReport");
            request.AddParameter("month", month);
            request.AddParameter("year", year);
            // The cancellation token comes from the caller. You can still make a call without it.
            var response = await client.GetAsync(request);
            var result = JsonSerializer.Deserialize<double[]>(response.Content);

            return result;
        }
    }
}
