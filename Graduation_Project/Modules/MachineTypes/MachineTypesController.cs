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
        try
        {
            var machineTypes = await machineTypesService.GetAll();
            return Ok(machineTypes);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute]int id)
    {
        try
        {
            var machineType = await machineTypesService.GetById(id);
            return Ok(machineType);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody]MachineTypeRequestDto machineTypeRequestDto)
    {
        
        try
        {
            await machineTypesService.Add(machineTypeRequestDto);
            return Created();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    
}