using BuildingManager.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Net;

namespace BuildingManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuildingController : ControllerBase
    {
        private readonly ILogger<BuildingController> _logger;
        private readonly IBuildingService _buildingService;

        public BuildingController(ILogger<BuildingController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAll")]
        public IEnumerable<Building> GetAll()
        {
            return new List<Building>();
        }

        [HttpGet(Name = "GetBuilding")]
        public Building GetBuilding(string type)
        {
            return new Building();
        }

        [HttpGet(Name = "GetGasUsage")]
        public Building GetGasUsage(string type, int month, int year)
        {
            return new Building();
        }
    }
}