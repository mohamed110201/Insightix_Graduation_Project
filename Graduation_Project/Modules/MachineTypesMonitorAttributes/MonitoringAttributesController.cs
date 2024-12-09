using System.Net;
using FluentValidation;
using Graduation_Project.Core;
using Graduation_Project.DTOs;
using Graduation_Project.Services.Interfaces;
using Graduation_Project.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers;

[ApiController]
[Route("api/machine-types/{machineTypeId:int}/monitoring-attributes")]
public class MachineTypesMonitorAttributesController(IMonitoringAttributesService monitoringAttributesService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetMonitorAttributesByMachineTypeId([FromRoute] int machineTypeId)
    {
        var monitoringAttributes = await monitoringAttributesService.GetByMachineTypeId(machineTypeId);
        return JSend.Success(data:monitoringAttributes);
    }
    
}