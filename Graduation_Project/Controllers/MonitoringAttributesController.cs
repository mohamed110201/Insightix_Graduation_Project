using FluentValidation;
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
    public async Task<IActionResult> GetAll()
    {
        var monitoringAttributes = await monitoringAttributesService.GetAll();
        return Ok(monitoringAttributes);
    }

    [Route("")]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddMonitoringAttributeDto addMonitoringAttributeDto)
    {
        await monitoringAttributesService.Add(addMonitoringAttributeDto);
        return Ok();
    }
}