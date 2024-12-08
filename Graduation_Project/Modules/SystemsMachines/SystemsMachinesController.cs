using Graduation_Project.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers
{
    [Route("api/systems/{systemId:int}/machines")]
    [ApiController]
    public class SystemsMachinesController(IMachinesService machinesService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMachinesBySystemId([FromRoute]int systemId)
        {
            var machines = await machinesService.GetMachinesBySystemId(systemId);
            return Ok(machines);
        }
    }
}
