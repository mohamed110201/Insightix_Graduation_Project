using System.Net;
using FluentValidation;
using Graduation_Project.Core;
using Graduation_Project.DTOs;
using Graduation_Project.Services.Interfaces;
using Graduation_Project.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers;

[ApiController]
[Route("[controller]")]
public class MonitoringAttributesController(IMonitoringAttributesService monitoringAttributesService) : ControllerBase
{
    [Route("")]
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var monitoringAttributes = await monitoringAttributesService.GetAll();
        return JSend.Success(data:monitoringAttributes);
    }

    [Route("")]
    [HttpPost]
    public async Task<ActionResult> Add([FromBody] AddMonitoringAttributeDto addMonitoringAttributeDto)
    {
        await monitoringAttributesService.Add(addMonitoringAttributeDto);
        return JSend.Created(message:"Monitoring Attribute Added Successfully");
    }
}