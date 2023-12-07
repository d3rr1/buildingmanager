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

        public BuildingService(IServiceProvider serviceProvider, IGasContractAgent gasContract)
        {
            _serviceProvider = serviceProvider;
            _gasContractAgent = gasContract;
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
            await _buildingAgent.GetGasPerMonthAsync(buildingUsage, month, year);

            var building = new Building
            {
                Id = buildingUsage.Id,
                Name = buildingUsage.Name,
                MonthlyGasUsage = buildingUsage.GasUsage
            };

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
