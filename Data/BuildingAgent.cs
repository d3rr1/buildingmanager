using Data.Responses;
using RestSharp;
using System.Text.Json;

namespace Data
{
    public class BuildingAgent<T> : IBuildingAgent<T>
    {
        public T GetAll()
        {
            throw new NotImplementedException();
        }

        public BuildingGasUsage GetBuildingInfo()
        {
            var options = new RestClientOptions("https://designdaysbuilding1.azurewebsites.net/");
            var client = new RestClient(options);
            var request = new RestRequest("building/info");

            var response = client.Get(request);
            var result = JsonSerializer.Deserialize<Building1InfoResponse>(response.Content);

            return new BuildingGasUsage()
            {
                Id = result.Id.ToString(),
                Name = result.Name,
                GasUsage = new List<double>()
            };
        }

        public async Task<BuildingGasUsage> GetGasPerMonthAsync(BuildingGasUsage buildingGasUsage, int month, int year)
        {
            var options = new RestClientOptions("https://designdaysbuilding1.azurewebsites.net/");
            var client = new RestClient(options);
            var request = new RestRequest("building/gasusage");
            request.AddParameter("month", month);
            request.AddParameter("year", year);
            // The cancellation token comes from the caller. You can still make a call without it.
            var response = await client.GetAsync(request);
            var result = JsonSerializer.Deserialize<Building1GasResponse>(response.Content);

            foreach(var item in result.GasUsage)
            {
                buildingGasUsage.GasUsage.Add(Convert.ToDouble(item));
            }

            return buildingGasUsage;
        }
    }
}
