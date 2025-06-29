using Graduation_Project.Core.JSend;
using Graduation_Project.DTOs;
using Graduation_Project.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Modules.MonitoringAttributes;

[ApiController]
[Route("api/monitoring-attributes")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

public class MonitoringAttributesController(IMonitoringAttributesService monitoringAttributesService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var monitoringAttributes = await monitoringAttributesService.GetAll();
        return JSend.Success(data:monitoringAttributes);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddMonitoringAttributeDto addMonitoringAttributeDto)
    {
        await monitoringAttributesService.Add(addMonitoringAttributeDto);
        return JSend.Created(message:"Monitoring Attribute Added Successfully");
    }
}