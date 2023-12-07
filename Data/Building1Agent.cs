using Data.Responses;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Text.Json;

namespace Data
{
    public class Building1Agent : IBuildingAgent
    {
        private readonly IConfiguration _configuration;
        private readonly string url;

        public Building1Agent(IConfiguration configuration)
        {
            _configuration = configuration;
            url = _configuration["ConnectionStrings:Building1"];
        }

        public List<BuildingUsage> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<BuildingUsage> GetBuildingInfoAsync()
        {
            var options = new RestClientOptions(url);
            var client = new RestClient(options);
            var request = new RestRequest("building/info");

            var response = await client.GetAsync(request);
            var result = JsonSerializer.Deserialize<Building1InfoResponse>(response.Content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return new BuildingUsage()
            {
                Id = result.Id.ToString(),
                Name = result.Name,
                GasUsage = new List<double>()
            };
        }

        public async Task<List<double>> GetGasPerMonthAsync(int month, int year)
        {
            var options = new RestClientOptions(url);
            var client = new RestClient(options);
            var request = new RestRequest("building/gasusage");
            request.AddParameter("month", month);
            request.AddParameter("year", year);
            // The cancellation token comes from the caller. You can still make a call without it.
            var response = await client.GetAsync(request);
            var result = JsonSerializer.Deserialize<int[]>(response.Content);

            var convertedResults = new List<double>();
            foreach(var item in result)
            {
                convertedResults.Add(Convert.ToDouble(item));
            }

            return convertedResults;
        }

        public Task<List<double>> GetWeatherPerMonthAsync(int month, int year)
        {
            throw new NotImplementedException();
        }
    }
}
