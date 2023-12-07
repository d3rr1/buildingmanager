using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IBuildingAgent
    {
        public Task<List<double>> GetInsideTemperature(int month, int year);
        public Task<List<double>> GetGasPerMonthAsync(int month, int year);
        public Task<BuildingUsage> GetBuildingInfoAsync();
        public List<BuildingUsage> GetAll();
    }
}
