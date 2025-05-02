using Graduation_Project.Core.JSend;
using Graduation_Project.Data.Dtos.Machine;
using Graduation_Project.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers
{
    [Route("api/systems/{systemId:int}/machines")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class SystemsMachinesController(IMachinesService machinesService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMachinesBySystemId([FromRoute]int systemId)
        {
            var machines = await machinesService.GetMachinesBySystemId(systemId);
            return JSend.Success(data:machines);
        }

        [HttpPost]
        public async Task<IActionResult> AddMachineToSystem([FromRoute] int systemId, [FromBody] AddMachineToSystemDto AddMachineToSystemDto)
        {
           await machinesService.AddMachineToSystem(systemId, AddMachineToSystemDto);
           return JSend.Success();
        }
    }




}
