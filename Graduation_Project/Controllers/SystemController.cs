using Graduation_Project.Data.Dtos.SystemDto;
using Graduation_Project.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        private readonly ISystemService _systemService;

        public SystemController(ISystemService systemService)
        {
            _systemService = systemService;
        }

        [HttpPost]
        public IActionResult CreateSystem( SystemRequestDto systemRequestDto)
        {
            if (string.IsNullOrEmpty(systemRequestDto.Name))
            {
                return BadRequest("System name is required.");
            }

            var createdSystem = _systemService.AddSystem(systemRequestDto);
            return CreatedAtAction(nameof(GetSystemById), new { systemId = createdSystem.Id }, createdSystem);
        }

        [HttpGet]
        public IActionResult GetAllSystems()
        {
            var systems = _systemService.GetAllSystems();
            return Ok(systems);
        }

        // GET /systems/{systemId}
        [HttpGet("{systemId:int}")]
        public IActionResult GetSystemById(int systemId)
        {
            var system = _systemService.GetSystemById(systemId);
            if (system == null)
            {
                return NotFound($"System with ID {systemId} not found.");
            }

            return Ok(system);
        }
    }
}
