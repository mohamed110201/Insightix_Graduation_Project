using System.Net;
using FluentValidation;
using Graduation_Project.Core;
using Graduation_Project.Core.JSend;
using Graduation_Project.DTOs;
using Graduation_Project.Services.Interfaces;
using Graduation_Project.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers;

[ApiController]
[Route("api/machine-types/{machineTypeId:int}/resource-consumption-attributes")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

public class MachineTypesResourceConsumptionAttributesController(IResourceConsumptionAttributesService resourceConsumptionAttributesService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetResourceConsumptionAttributesByMachineTypeId([FromRoute] int machineTypeId)
    {
        var getAllResourceConsumptionAttributeDtos = await resourceConsumptionAttributesService.GetByMachineTypeId(machineTypeId);
        return JSend.Success(data:getAllResourceConsumptionAttributeDtos);
    }
    
}