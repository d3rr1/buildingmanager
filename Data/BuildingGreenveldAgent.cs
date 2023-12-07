using Data.Responses;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Text.Json;

namespace Data
{
    public class BuildingGreenveldAgent : IBuildingAgent
    {
        private readonly IConfiguration _configuration;
        private readonly string url;

        public BuildingGreenveldAgent(IConfiguration configuration)
        {
            _configuration = configuration;
            url = _configuration["ConnectionStrings:BuildingGreenveld"];
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
            var result = JsonSerializer.Deserialize<BuildingGreenveldInfoResponse>(response.Content);

            return new BuildingUsage()
            {
                Id = result.BuildingIdentifier.ToString(),
                Name = result.Name,
                GasUsage = new List<double>()
            };
        }

        public async Task<BuildingUsage> GetGasPerMonthAsync(BuildingUsage buildingGasUsage, int month, int year)
        {
            var options = new RestClientOptions(url);
            var client = new RestClient(options);
            var request = new RestRequest("building/gasusage");
            request.AddParameter("month", month);
            request.AddParameter("year", year);
            // The cancellation token comes from the caller. You can still make a call without it.
            var response = await client.GetAsync(request);
            var result = JsonSerializer.Deserialize<double[]>(response.Content);

            foreach (var item in result)
            {
                buildingGasUsage.GasUsage.Add(Convert.ToDouble(item));
            }

            return buildingGasUsage;
        }

        public Task<List<double>> GetGasPerMonthAsync(int month, int year)
        {
            throw new NotImplementedException();
        }
    }
}
