using Data.Responses;
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
    public class GasContractAgent : IGasContractAgent
    {
        private readonly IConfiguration _configuration;
        private string _url;

        public GasContractAgent(IConfiguration configuration)
        {
            _configuration = configuration;
            _url = _configuration["ConnectionStrings:PowerCompany"];
        }
        public async Task<double> GetGasContract(string id)
        {
            var options = new RestClientOptions(_url);
            var client = new RestClient(options);
            var request = new RestRequest("Contract/PowerContract");

            var response = await client.GetAsync(request);
            var result = JsonSerializer.Deserialize<GasContract>(response.Content);

            return result.GasPrice;
        }
    }
}
