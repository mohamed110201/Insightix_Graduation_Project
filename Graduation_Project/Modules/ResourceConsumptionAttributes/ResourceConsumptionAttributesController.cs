using System.Net;
using FluentValidation;
using Graduation_Project.Core;
using Graduation_Project.DTOs;
using Graduation_Project.Services.Interfaces;
using Graduation_Project.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers;

[ApiController]
[Route("api/resource-consumption-attributes")]
public class ResourceConsumptionControllerAttributesController(IResourceConsumptionAttributesService resourceConsumptionAttributesService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var resourceConsumptionAttributeDtos = await resourceConsumptionAttributesService.GetAll();
        return JSend.Success(data:resourceConsumptionAttributeDtos);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddResourceConsumptionAttributeDto addResourceConsumptionAttributeDto)
    {
        await resourceConsumptionAttributesService.Add(addResourceConsumptionAttributeDto);
        return JSend.Created(message:"ResourceConsumption Attribute Added Successfully");
    }
}