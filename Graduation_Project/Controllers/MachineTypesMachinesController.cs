using Graduation_Project.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers;

[Route("api/MachineType/Machines")]
[ApiController]
public class MachineTypesMachinesController : Controller
{

    private readonly IMachineServices _machineTypeServices;
    [HttpGet("{MachineTypeId:int}")]
    public IActionResult GetMachinesByMachineTypeId([FromRoute]int machineTypeId)
    {
        var machines = _machineTypeServices.GetMachinesByMachineTypeIdAsync(machineTypeId);
        return Ok(machines);
    }
}