using Domain.Models;

namespace Domain.Interfaces
{
    public interface IBuildingService
    {
        public IEnumerable<Building> GetAll();
        public Building GetBuildingInfo(string type);
        public Task<Building> GetGasUsage(string type, int month, int year);
    }
}
 