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

        [HttpGet]
        [Route("/getbuildings")]
        public IEnumerable<Building> GetAll()
        {
            return _buildingService.GetAll();
        }

        [HttpGet]
        [Route("/getbuilding/{type}")]
        public Building GetBuilding(string type)
        {
            return _buildingService.GetBuildingInfo(type);
        }

        [HttpGet]
        [Route("/getgasusage/{type}/{year}/{month}")]
        public Building GetGasUsage(string type, int month, int year)
        {
            return _buildingService.GetGasUsage(type, month, year);
        }
    }
}