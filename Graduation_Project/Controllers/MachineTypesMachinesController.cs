using Graduation_Project.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers;

[Route("api/machineTypes/{machineTypeId:int}/machines")]
[ApiController]
public class MachineTypesMachinesController : Controller
{

    private readonly IMachineService _machineTypeService;
    [HttpGet]
    public IActionResult GetMachinesByMachineTypeId([FromRoute]int machineTypeId)
    {
        var machines = _machineTypeService.GetMachinesByMachineTypeIdAsync(machineTypeId);
        return Ok(machines);
    }
}