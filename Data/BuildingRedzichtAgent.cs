using Data.Responses;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Text.Json;

namespace Data
{
    public class BuildingRedzichtAgent : IBuildingAgent
    {
        private readonly IConfiguration _configuration;
        private readonly string url;

        public BuildingRedzichtAgent(IConfiguration configuration)
        {
            _configuration = configuration;
            url = _configuration["ConnectionStrings:BuildingRedzicht"];
        }

        public List<BuildingUsage> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<BuildingUsage> GetBuildingInfoAsync()
        {

            return new BuildingUsage()
            {
                Id = "4716297",
                Name = "4716297",
                GasUsage = new List<double>()
            };
        }

        public async Task<BuildingUsage> GetGasPerMonthAsync(BuildingUsage buildingGasUsage, int month, int year)
        {
            var options = new RestClientOptions(url);
            var client = new RestClient(options);
            var request = new RestRequest("building/daysinfo");

            var startDate = new DateTime(year, month, 1);
            var numberofDays = DateTime.DaysInMonth(year, month);


            request.AddParameter("startDate", startDate);
            request.AddParameter("numberOfDays", numberofDays);
            // The cancellation token comes from the caller. You can still make a call without it.
            var response = await client.GetAsync(request);
            var result = JsonSerializer.Deserialize < BuildingRedzichtGasResponse[]>(response.Content);

            foreach (var item in result)
            {
                buildingGasUsage.GasUsage.Add(Convert.ToDouble(item.GasUsage));
            }

            return buildingGasUsage;
        }

        public Task<List<double>> GetGasPerMonthAsync(int month, int year)
        {
            throw new NotImplementedException();
        }

        public Task<List<double>> GetWeatherPerMonthAsync(int month, int year)
        {
            throw new NotImplementedException();
        }
    }
}
