using Graduation_Project.Data.Dtos.SystemDto;
using Graduation_Project.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers
{
    [Route("api/systems")]
    [ApiController]
    public class SystemsController(ISystemsService systemsService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]SystemRequestDto systemRequestDto)
        {
            if (string.IsNullOrEmpty(systemRequestDto.Name))
            {
                return BadRequest("System name is required.");
            }

            await systemsService.Add(systemRequestDto);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var systems =await  systemsService.GetAll();
            return Ok(systems);
        }

        [HttpGet("{systemId:int}")]
        public async Task<IActionResult> GetById([FromRoute]int systemId)
        {
            var system = await systemsService.GetById(systemId);
            if (system == null)
            {
                return NotFound($"System with ID {systemId} not found.");
            }

            return Ok(system);
        }
    }
}
