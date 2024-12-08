using Graduation_Project.Services.Implementation;
using Graduation_Project.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly IMachineService _machineService;

        public MachineController(IMachineService machineService)
        {
            _machineService = machineService;
        }
        [HttpGet]
        public IActionResult GetAllMachines()
        {
            var Machines = _machineService.GetAllMachines();
            return Ok(Machines);
            
        }
        // GET /Machine/{MachineId}
        [HttpGet("{MachineId:int}")]
        public IActionResult GetMachineById(int MachineId)
        {
            var Machine = _machineService.GetMachineById(MachineId);
            if (Machine == null)
            {
                return NotFound($"Machine with ID {MachineId} not found.");
            }

            return Ok(Machine);
        }
    }
}
