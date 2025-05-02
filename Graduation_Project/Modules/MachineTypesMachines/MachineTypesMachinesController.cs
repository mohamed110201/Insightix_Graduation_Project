using Graduation_Project.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers;

[Route("api/machine-types/{machineTypeId:int}/machines")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

public class MachineTypesMachinesController(IMachinesService machinesTypeService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetMachinesByMachineTypeId([FromRoute]int machineTypeId)
    {
        var machines = await machinesTypeService.GetMachinesByMachineTypeId(machineTypeId);
        return Ok(machines);
    }
}