using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;

namespace BuildingManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuildingController : ControllerBase
    {
        private readonly ILogger<BuildingController> _logger;
        private readonly IBuildingService _buildingService;

        public BuildingController(ILogger<BuildingController> logger, IBuildingService buildingService)
        {
            _logger = logger;
            _buildingService = buildingService;
        }

        [HttpGet(Name = "GetAll")]
        public IEnumerable<Building> GetAll()
        {
            return _buildingService.GetAll();
        }

        [HttpGet(Name = "GetBuilding")]
        public Building GetBuilding(string type)
        {
            return _buildingService.GetBuildingInfo(type);
        }

        [HttpGet(Name = "GetGasUsage")]
        public Building GetGasUsage(string type, int month, int year)
        {
            return _buildingService.GetGasUsage(type, month, year);
        }
    }
}