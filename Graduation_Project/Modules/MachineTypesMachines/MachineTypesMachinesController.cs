using Graduation_Project.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers;

[Route("api/machine-types/{machineTypeId:int}/machines")]
[ApiController]
public class MachineTypesMachinesController(IMachinesService machinesTypeService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetMachinesByMachineTypeId([FromRoute]int machineTypeId)
    {
        var machines = await machinesTypeService.GetMachinesByMachineTypeId(machineTypeId);
        return Ok(machines);
    }
}