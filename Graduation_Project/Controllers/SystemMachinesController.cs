using Graduation_Project.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers
{
    [Route("api/Systems/{systemId:int}/Machines")]
    [ApiController]
    public class SystemMachinesController : ControllerBase
    {
        private readonly IMachineService _machineService;

        public SystemMachinesController(IMachineService machineService)
        {
            _machineService = machineService;
        }
        [HttpGet("{systemId:int}")]
        public IActionResult GetMachinesBySystemId(int systemId)
        {
            var Machines = _machineService.GetMachinesBySystemId(systemId);
            return Ok(Machines);
        }
    }
}
