using Graduation_Project.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers;

[Route("api/machineTypes/{machineTypeId:int}/machines")]
[ApiController]
public class MachineTypesMachinesController : Controller
{

    private readonly IMachineServices _machineTypeServices;
    [HttpGet]
    public IActionResult GetMachinesByMachineTypeId([FromRoute]int machineTypeId)
    {
        var machines = _machineTypeServices.GetMachinesByMachineTypeIdAsync(machineTypeId);
        return Ok(machines);
    }
}