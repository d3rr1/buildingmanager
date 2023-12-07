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
        public IEnumerable<Building> GetAll()
        {
            return new List<Building>();
        }
        public Building GetBuildingInfo(string type)
        {
            return new Building();
        }

        public Building GetGasUsage(string type, int month, int year)
        {
            return new Building();
        }
    }
}
