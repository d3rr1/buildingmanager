using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IBuildingAgent
    {
        public Task<double[]> GetGasPerMonthAsync(int month, int year);
        public Task<double[]> GetWeatherPerMonthAsync(int month, int year);
        public Task<BuildingUsage> GetBuildingInfoAsync();
        public List<BuildingUsage> GetAll();
    }
}
