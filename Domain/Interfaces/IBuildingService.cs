using Domain.Models;

namespace Domain.Interfaces
{
    public interface IBuildingService
    {
        public IEnumerable<Building> GetAll();
        public Building GetBuildingInfo(BuildingType type);
        public Task<Building> GetGasUsage(BuildingType type, int month, int year);
    }
}
 