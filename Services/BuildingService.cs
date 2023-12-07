using Data;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingAgent _buildingAgent;

        public BuildingService(IBuildingAgent buildingAgent)
        {
            _buildingAgent = buildingAgent;   
        }
        public IEnumerable<Building> GetAll()
        {
            return new List<Building>();
        }
        public Building GetBuildingInfo(string type)
        {
            return new Building();
        }

        public async Task<Building> GetGasUsage(string type, int month, int year)
        {
            var buildingUsage = await _buildingAgent.GetBuildingInfoAsync();
            await _buildingAgent.GetGasPerMonthAsync(buildingUsage, month, year);

            var building = new Building
            {
                Id = buildingUsage.Id,
                Name = buildingUsage.Name,
                MonthlyGasUsage = buildingUsage.GasUsage
            };

            return building;
        }
    }
}
