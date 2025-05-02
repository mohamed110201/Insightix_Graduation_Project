using Graduation_Project.Core.JSend;
using Graduation_Project.Modules.Alerts.Service;
using Graduation_Project.Modules.FailuresPrediction.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Modules.MachinesFailuresPrediction;

[Route("machines/{machineId:int}/failures")]
[ApiController]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

public class MachinesFailuresPredictionController(IFailuresPredictionService failuresPredictionService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetFailuresPredictionByMachineId([FromRoute]int machineId)
    {
        var alerts = await failuresPredictionService.GetByMachineId(machineId);
        return JSend.Success(data:alerts);
    }
}