using Graduation_Project.Core.JSend;
using Graduation_Project.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Modules.MachineTypesMonitorAttributes;

[ApiController]
[Route("api/machine-types/{machineTypeId:int}/monitoring-attributes")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

public class MachineTypesMonitorAttributesController(IMonitoringAttributesService monitoringAttributesService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetMonitorAttributesByMachineTypeId([FromRoute] int machineTypeId)
    {
        var monitoringAttributes = await monitoringAttributesService.GetByMachineTypeId(machineTypeId);
        return JSend.Success(data:monitoringAttributes);
    }
    
}