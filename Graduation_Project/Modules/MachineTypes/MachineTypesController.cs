using Graduation_Project.Core;
using Graduation_Project.Core.JSend;
using Graduation_Project.Data.Dtos.MachineTypeDto;
using Graduation_Project.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers;

[Route("api/machine-types")]
[ApiController]
public class MachineTypesController(IMachineTypesService machineTypesService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var machineTypes = await machineTypesService.GetAll();
        return JSend.Success(data:machineTypes);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        
            var machineType = await machineTypesService.GetById(id);
            return JSend.Success(data:machineType);
       
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] MachineTypeRequestDto machineTypeRequestDto)
    {
            await machineTypesService.Add(machineTypeRequestDto);
            return JSend.Created(message:"Machine Type Added Successfully");
            
    }
}