using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IBuildingAgent<T>
    {
        public List<BuildingGasUsage> GetGasPerMonthAsync(int month, int year);
        public T GetBuildingInfo();

        public T GetAll();
    }
}
