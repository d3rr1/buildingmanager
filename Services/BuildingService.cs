using Data;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Services
{
    public class BuildingService : IBuildingService
    {
        private IBuildingAgent _buildingAgent;
        private IGasContractAgent _gasContractAgent;
        private readonly IServiceProvider _serviceProvider;
        private IWeatherAgent _weatherAgent;

        public BuildingService(IServiceProvider serviceProvider, IGasContractAgent gasContract, IWeatherAgent weatherAgent)
        {
            _serviceProvider = serviceProvider;
            _gasContractAgent = gasContract;
            _weatherAgent = weatherAgent;
        }
        public IEnumerable<Building> GetAll()
        {
            return new List<Building>();
        }
        public Building GetBuildingInfo(BuildingType type)
        {
            CreateBuildingAgent(type);

            return new Building();
        }

        public async Task<Building> GetGasUsage(BuildingType type, int month, int year)
        {
            CreateBuildingAgent(type);

            var buildingUsage = await _buildingAgent.GetBuildingInfoAsync();
            var gasUsage = await _buildingAgent.GetGasPerMonthAsync(month, year);
            var weather = await _weatherAgent.GetMonthlyWeather(month, year);

            var building = new Building
            {
                Id = buildingUsage.Id,
                Name = buildingUsage.Name,
                MonthlyGasUsage = new List<GasInfo>()
            };

            for (int i = 0; i < gasUsage.Length; i++)
            {
                var gasInfo = new GasInfo()
                {
                    Day = i+1,
                    GasUsage = gasUsage[i],
                    OutTemp = weather[i]
                };
                building.MonthlyGasUsage.Add(gasInfo);
            }

            building.GasPrice = await _gasContractAgent.GetGasContract(buildingUsage.Id);

            return building;
        }

        private void CreateBuildingAgent(BuildingType type)
        {
            var services = _serviceProvider.GetServices<IBuildingAgent>();
            switch (type)
            {
                case BuildingType.Building1:
                    _buildingAgent = services.First(o => o.GetType() == typeof(Building1Agent));
                    break;
                case BuildingType.Redzicht:
                    _buildingAgent = services.First(o => o.GetType() == typeof(BuildingRedzichtAgent));
                    break;
                case BuildingType.Greenveld:
                    _buildingAgent = services.First(o => o.GetType() == typeof(BuildingGreenveldAgent));
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
