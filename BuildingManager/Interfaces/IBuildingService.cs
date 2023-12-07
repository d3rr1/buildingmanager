using BuildingManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBuildingService
    {
        public IEnumerable<Building> GetAll();
        public Building GetBuildingInfo(string type);
        public Building GetGasUsage(string type, int month, int year);
    }
}
 