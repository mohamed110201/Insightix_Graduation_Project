using Graduation_Project.Core.JSend;
using Graduation_Project.Modules.Alerts.Service;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers;

[Route("machines/{machineId:int}/alerts")]
[ApiController]
public class MachinesAlertsController(IAlertsService alertsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAlertsByMachineId([FromRoute]int machineId)
    {
        var alerts = await alertsService.GetAlertsByMachineId(machineId);
        return JSend.Success(data:alerts);
    }
}